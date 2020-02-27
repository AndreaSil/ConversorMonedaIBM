using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ConversorMonedaIBM.Controllers;
using ConversorMonedaIBM.Models.Data;
using ConversorMonedaIBM.Models.WebAPI;
using ConversorMonedaIBM.Services.ChekURL;
using ConversorMonedaIBM.Services.Deserializer;
using ConversorMonedaIBM.Services.Factory;
using ConversorMonedaIBM.Services.Logs;
using ConversorMonedaIBM.Services.Logs;
using ConversorMonedaIBM.Services.Repository;
using ConversorMonedaIBM.Services.Specification.ConversionSpecification;
using ConversorMonedaIBM.Services.Specification.Interface;
using ConversorMonedaIBM.Services.Specification.TransactionSpecification;

namespace ConversorMonedaIBM
{
    public class IoCConfiguration
    {
        public static void RegistrarControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }

        public static void ResgistrarRepos(ContainerBuilder builder)
        {
            builder.RegisterType<GenericRepository<Transaction>>().As<IGenericRepository<Transaction>>()
                .InstancePerRequest();

            builder.RegisterType<GenericRepository<Conversion>>().As<IGenericRepository<Conversion>>()
                .InstancePerRequest();

        }

        public static void RegistrarClases(ContainerBuilder builder)
        {


            builder.RegisterType<Log>().As<ILog>();
            builder.RegisterType<CurrencyTransactionSpecification>().As<ISpecification<WebApiTransactionData.Class1>>();
            builder.RegisterType<AmountTransactionSpecification>().As<ISpecification<WebApiTransactionData.Class1>>();
            builder.RegisterType<SkuTransactionSpecification>().As<ISpecification<WebApiTransactionData.Class1>>();
            builder.RegisterType<FromConversionSpecification>().As<ISpecification<WebApiConversionData.Class1>>();
            builder.RegisterType<RateConversionSpecification>().As<ISpecification<WebApiConversionData.Class1>>();
            builder.RegisterType<ToConversionSpecification>().As<ISpecification<WebApiConversionData.Class1>>();
            builder.RegisterType<TransactionFactory>().As<IOperationFactory<Transaction>>();
            builder.RegisterType<ConversionFactory>().As<IOperationFactory<Conversion>>();
            builder.RegisterType<CheckURL>().As<ICheckURL>();
            builder.RegisterType<ConversionDeserializer>().As<IDeserializer<WebApiConversionData.Class1>>();
            builder.RegisterType<TransactionDeserializer>().As<IDeserializer<WebApiTransactionData.Class1>>();
            builder.Register(z => new TransactionsController()).
                InstancePerRequest();
            builder.Register(z => new ConversionsController()).
                InstancePerRequest();

        }

        public static void Configure()
        {
            ContainerBuilder builder= new ContainerBuilder();
           
            ResgistrarRepos(builder);
            RegistrarClases(builder);
            RegistrarControllers(builder);


            IContainer contenedor = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(contenedor));
        }
    }


}
