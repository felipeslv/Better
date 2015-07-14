
using AutoMapper;
using Better.Domain.Entities;
using Better.MVC.ViewModels;

namespace Better.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Estacionamento, EstacionamentoViewModel>();
            Mapper.CreateMap<TabelaValor, TabelaValorViewModel>();
        }
    }
}