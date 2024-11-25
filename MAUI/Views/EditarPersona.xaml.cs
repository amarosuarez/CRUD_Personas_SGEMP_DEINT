using ENT;

namespace MAUI.Views;

public partial class EditarPersona : ContentPage, IQueryAttributable
{
	public EditarPersona()
	{
        InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        clsPersona persona = query["persona"] as clsPersona;
        BindingContext = persona;
    }
}