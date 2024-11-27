namespace ENT
{
    public class clsPersona
    {
        #region Atributos
        private int id;
        private String nombre;
        private String apellidos;
        private string telefono;
        private String direccion;
        private String foto;
        //[Column ("FechaNacimiento")]
        private DateTime fechaNacimiento;
        private int idDepartamento;
        #endregion

        #region Propiedades
        public int Id
        {
            get { return id; }
            set
            {
                if (value > 0)
                {
                    id = value;
                }
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nombre = value;
                }
            }
        }
        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    apellidos = value;
                }
            }
        }
        public string Telefono
        {
            get { return telefono; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    telefono = value;
                }
            }
        }
        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    direccion = value;
                }
            }
        }
        public string Foto
        {
            get { return foto; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    foto = value;
                }
            }
        }
        public DateTime FechaNacimiento { get { return fechaNacimiento; } set { fechaNacimiento = value; } }
        public int IdDepartamento
        {
            get { return idDepartamento; }
            set
            {
                if (value > 0)
                {
                    idDepartamento = value;
                }
            }
        }
        #endregion

        #region Constructores
        public clsPersona() { }

        public clsPersona(int id, string nombre, string apellidos, string telefono, string direccion, string foto, DateTime fechaNacimiento, int idDepartamento)
        {
            if (id > 0)
            {
                this.id = id;
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                this.nombre = nombre;
            }

            if (!String.IsNullOrEmpty(apellidos))
            {
                this.apellidos = apellidos;
            }

            if (!string.IsNullOrEmpty(telefono))
            {
                this.telefono = telefono;
            }

            if (!string.IsNullOrEmpty(direccion))
            {
                this.direccion = direccion;
            }

            if (!string.IsNullOrEmpty(foto))
            {
                this.foto = foto;
            }

            this.fechaNacimiento = fechaNacimiento;

            if (idDepartamento > 0)
            {
                this.idDepartamento = idDepartamento;
            }
        }
        #endregion
    }
}
