﻿using Autofac;
using NAPS2.EtoForms;
using NAPS2.EtoForms.Desktop;
using NAPS2.EtoForms.Ui;
using NAPS2.EtoForms.WinForms;
using NAPS2.ImportExport;
using NAPS2.ImportExport.Pdf;
using NAPS2.Scan;
using NAPS2.Scan.Batch;
using NAPS2.Update;
using NAPS2.WinForms;

namespace NAPS2.Modules;

public class WinFormsModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // TODO: Move common registrations (between WinForms/Mac/Gtk) to a GuiModule
        builder.RegisterType<BatchScanPerformer>().As<IBatchScanPerformer>();
        builder.RegisterType<MessageBoxErrorOutput>().As<ErrorOutput>();
        builder.RegisterType<EtoOverwritePrompt>().As<IOverwritePrompt>();
        builder.RegisterType<EtoOperationProgress>().As<OperationProgress>().SingleInstance();
        builder.RegisterType<EtoDialogHelper>().As<DialogHelper>();
        builder.RegisterType<EtoDevicePrompt>().As<IDevicePrompt>();
        builder.RegisterType<EtoPdfPasswordProvider>().As<IPdfPasswordProvider>();
        builder.RegisterType<NotificationManager>().As<INotificationManager>().SingleInstance();
        builder.Register<ISaveNotify>(ctx => ctx.Resolve<INotificationManager>());
        builder.RegisterType<PrintDocumentPrinter>().As<IScannedImagePrinter>();
        builder.RegisterType<DesktopController>().AsSelf().SingleInstance();
        builder.RegisterType<UpdateChecker>().As<IUpdateChecker>();
        builder.RegisterType<ExportController>().As<IExportController>();
        builder.RegisterType<DesktopScanController>().As<IDesktopScanController>();
        builder.RegisterType<DesktopSubFormController>().As<IDesktopSubFormController>();
        builder.RegisterType<DesktopFormProvider>().AsSelf().SingleInstance();

        builder.RegisterType<WinFormsDesktopForm>().As<DesktopForm>();

        EtoPlatform.Current = new WinFormsEtoPlatform();
        // TODO: Can we add a test for this?
        builder.RegisterBuildCallback(ctx =>
            Log.EventLogger = ctx.Resolve<WindowsEventLogger>());
    }
}