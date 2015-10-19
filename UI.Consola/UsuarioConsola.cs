using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocios;
using Entidades;


namespace UI.Consola
{
    public class UsuarioConsola
    {

        #region Constructor
        public UsuarioConsola()
        {
            this.UsuarioNegocio = new UsuarioNegocio();
        } 
        #endregion

        #region Miembros
        private UsuarioNegocio _UsuarioNegocio;
        #endregion

        #region Propiedades

        public UsuarioNegocio UsuarioNegocio
        {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value; }
        }
        #endregion

        #region Metodos
        public void Menu()
        {

            Console.Clear();
            Console.WriteLine("Menu");

            Console.WriteLine("1– Listado General");
            Console.WriteLine("2– Consulta");
            Console.WriteLine("3– Agregar");
            Console.WriteLine("4- Modificar");
            Console.WriteLine("5- Eliminar");
            Console.WriteLine("6- Salir");

            Console.WriteLine("Ingrese opcion: ");
            ConsoleKeyInfo opcion = Console.ReadKey();

            switch (opcion.Key)   //NOTA: NO FUNCIONA CON EL TECLADO NUMERICO DE LA DERECHA!!
            {
                case ConsoleKey.D1:
                    {
                        this.ListadoGeneral();
                        Console.ReadKey();
                        this.Menu();
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        this.Consultar();
                        this.Menu();
                        break;
                    }
                /*case ConsoleKey.D3:
                    {
                        this.Agregar();
                        Console.ReadKey();
                        this.Menu();
                        break;
                    }*/
                case ConsoleKey.D4:
                    {
                        Modificar();
                        this.Menu();
                        break;
                    }
                case ConsoleKey.D5:
                    {
                        Eliminar();
                        this.Menu();
                        break;
                    }
                /*case ConsoleKey.D6:
                    {
                       
                        break;
                    }
                    }
                default:
                    {
                        
                        break;
                    }*/
            }



        }

        public void ListadoGeneral()
        {
            Console.Clear();
            List<Usuario> usr = UsuarioNegocio.GetAll();
            foreach (Usuario usu in usr)
            {
                MostrarDatos(usu);
            }

        }

        public void MostrarDatos(Usuario usu)
        {
            Console.WriteLine("Usuario ID: {0}", usu.Id);
            Console.WriteLine("\t\tNombre: {0}", usu.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usu.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usu.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usu.Clave);
            Console.WriteLine("\t\tEmail: {0}", usu.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usu.Habilitado);
            Console.WriteLine();

        }

        public void Consultar()
        {

            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese ID: ");
                int Identif = Int32.Parse(Console.ReadLine());
                Usuario usu = UsuarioNegocio.GetOne(Identif);
                this.MostrarDatos(usu);
            }
            catch (FormatException)
            {
                Console.WriteLine("La ID debe ser un numero entero.");
            }
            catch(Exception)
            {
                Console.WriteLine("La ID es incorrecta.");
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }
            
        }

        /*public void Agregar()
        {

        }*/

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese ID a modificar: ");
                int Identif = Int32.Parse(Console.ReadLine());
                Usuario usu = UsuarioNegocio.GetOne(Identif);
                this.MostrarDatos(usu);
                Console.WriteLine("Nuevo Nombre: ");
                usu.Nombre = Console.ReadLine();
                Console.WriteLine("Nuevo Apellido: ");
                usu.Apellido= Console.ReadLine();
                Console.WriteLine("Nuevo Nombre de Usuario: ");
                usu.NombreUsuario = Console.ReadLine();
                Console.WriteLine("Nueva Clave: ");
                usu.Clave = Console.ReadLine();
                Console.WriteLine("Nuevo Email: ");
                usu.Email = Console.ReadLine();
                usu.Estado= Entidad.Estados.Modificado;
                Console.WriteLine("Habilitado? 1-SI / 2-NO ");
                usu.Habilitado = (Console.ReadLine() == "1"); //POR QUE????
                this.UsuarioNegocio.Save(usu);
            }
            catch (FormatException)
            {
                Console.WriteLine("La ID debe ser un numero entero.");
            }
            catch (Exception)
            {
                Console.WriteLine("La ID es incorrecta.");
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }
        }


        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese ID a eliminar: ");
                int Identif = Int32.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(Identif);
                
            }
            catch (FormatException)
            {
                Console.WriteLine("La ID debe ser un numero entero.");
            }
            catch (Exception)
            {
                Console.WriteLine("La ID es incorrecta.");
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }

        }
        #endregion 
    }
}
