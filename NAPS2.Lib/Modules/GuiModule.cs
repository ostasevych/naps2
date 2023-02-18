using Autofac;
using NAPS2.EtoForms;
using NAPS2.EtoForms.Desktop;
using NAPS2.ImportExport;
using NAPS2.Pdf;
using NAPS2.Scan;
using NAPS2.Scan.Batch;
using NAPS2.Update;

namespace NAPS2.Modules;

public class GuiModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<BatchScanPerformer>().As<IBatchScanPerformer>();
        builder.RegisterType<MessageBoxErrorOutput>().As<ErrorOutput>();
        builder.RegisterType<EtoOverwritePrompt>().As<IOverwritePrompt>();
        builder.RegisterType<EtoOperationProgress>().As<OperationProgress>().SingleInstance();
        builder.RegisterType<EtoDialogHelper>().As<DialogHelper>();
        builder.RegisterType<EtoDevicePrompt>().As<IDevicePrompt>();
        builder.RegisterType<EtoPdfPasswordProvider>().As<IPdfPasswordProvider>();
        builder.Register<ISaveNotify>(ctx => ctx.Resolve<INotificationManager>());
        builder.RegisterType<DesktopController>().AsSelf().SingleInstance();
        builder.RegisterType<UpdateChecker>().As<IUpdateChecker>();
        builder.RegisterType<ExportController>().As<IExportController>();
        builder.RegisterType<DesktopScanController>().As<IDesktopScanController>();
        builder.RegisterType<DesktopSubFormController>().As<IDesktopSubFormController>();
        builder.RegisterType<DesktopFormProvider>().AsSelf().SingleInstance();
    }
}