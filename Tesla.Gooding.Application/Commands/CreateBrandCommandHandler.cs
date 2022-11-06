using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tesla.Gooding.Application.CheckEvents;
using Tesla.Gooding.Application.Extensions;
using Tesla.Gooding.DataContract.Common;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;
using Tesla.Gooding.Infrastructure.Repositories;

namespace Tesla.Gooding.Application.Commands
{
    internal class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;
        private readonly IMediator _mediator;

        public CreateBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository, IMediator mediator)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var tenantId = await _mediator.Send(new CheckParseTenantCommand(request.TenantId));
            await _mediator.Publish(new CheckBrandInfoDomainEvent(request));

            var brand = ConvertMap(request);
            brand.Create(tenantId, request.UserId);
            await _brandRepository.AddAsync(brand, cancellationToken);
            await _brandRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return true;
        }

        private Brand ConvertMap(CreateBrandCommand request)
        {
            var brand = _mapper.Map<Brand>(request);
            if (brand == null)
            {
                // 格式错误
                EnumCode.ErrConvertNull.ThrowLanMessage();
                return null;
            }

            return brand;
        }
    }
}
