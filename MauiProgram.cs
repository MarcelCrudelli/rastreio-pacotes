using Microsoft.Extensions.Logging;
using RastreioPacotesApp.Services;
using RastreioPacotesApp.ViewModels;
using RastreioPacotesApp.Views;

namespace RastreioPacotesApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
builder.Services.AddSingleton<IRastreamentoService, RastreamentoService>();
builder.Services.AddTransient<BuscaViewModel>();
builder.Services.AddTransient<ResultadoViewModel>();
builder.Services.AddTransient<BuscaPage>();
builder.Services.AddTransient<ResultadoPage>();

		return builder.Build();
	}
}
