using MAUI.Views;

namespace MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("listado-personas", typeof(ListadoPersonas));
            Routing.RegisterRoute("editar-persona", typeof(EditarPersona));
        }
    }
}
