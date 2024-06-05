using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using System.Data;
using System.Drawing;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using Word = Microsoft.Office.Interop.Word;
using System;

namespace Comisaria
{
    public partial class Form1 : Form
    {
        //VARIABLES
        //sumario
        string sumarioInput;
        string añoSumInput;
        string caratulaInput;
        string fiscaliaInput, dependenciaInput, sumarianteInput, secActuacionesInput, comisionadoInput, testigoInput;
        string magistradoInput, secretarioInput;
        string departamental;



        //hora y fecha actual
        string horaInput = DateTime.Now.ToString("HH:mm");
        string fechaLargaInput = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        string fechaCortaInput = DateTime.Now.ToString("dd/MM/yyyy");
        string localidadInput;

        //denunciante
        string nombreInput, aliasInput, nacionalidadInput, estadoCivilInput, edadInput, instruccionInput, profesionInput, calleInput, alturaInput, deptoInput, ciudadInput, fechaNacInput, fechaNacInvertida, lugarInput, documentoInput, telefonoInput, denunciaInput;
        
        //damificado
        string nombreDamInput;

        //acusado
        string nombreAcuInput;
        //rutas
        string ruta;
        string folderPath;

        //parametros archivo word
        //parametros
        object Nom = "Nombre"; //parametro1
        object ali = "Alias"; //parametro29
        object Nac = "Nacionalidad"; //parametro2
        object civ = "Civil"; //parametro3
        object ed = "Edad"; //parametro4
        object ins = "Instruccion"; //parametro5
        object pro = "Profesion"; //parametro6
        object dom = "Domicilio"; //parametro7
        object alt = "Altura"; //parametro8
        object dep = "Departamento"; //parametro9
        object lugDom = "LugarDomicilio"; //parametro33
        object lug = "Lugar"; //parametro10
        object fec = "Fecha"; //parametro11
        object doc = "Documento"; //parametro12
        object tel = "Telefono"; //parametro13
                                 //parametro iniciales
        object ciu = "Ciudad"; //parametro14
        object depa = "Departamental"; //parametro15
        object fecd = "FechaDenuncia"; //parametro16
        object hs = "Hora"; //parametro17
                            //parametros intervinientes
        object tes = "Testigo";//parametro18
        object fisc = "Fiscalia"; //parametro19
        object mag = "Magistrado"; //parametro20
        object sec = "Secretario"; //parametro21
        object sum = "Sumariante"; //parametro22
        object secSum = "SecSumario"; //parametro23
        object com = "Comisionado"; //parametro24
        object numSum = "NumSumario"; //parametro25
        object añoSum = "AñoSumario"; //parametro26
        object car = "Caratula"; //parametro27
        object den = "Denuncia"; //parametro28
        object añoCor = "AñoCorto"; //parametro30
                                    //parametro damnificado
        object dam = "Damnificado"; //parametro32
        object edDam = "EdadDamnificado"; //parametro34
        object docDam = "DocumentoDamnificado"; //parametro35
        object civDam = "EstadoCivilDamnificado"; //parametro36
        object insDam = "InstruccionDamnificado"; //parametro37
        object proDam = "ProfesionDamnificado"; //parametro38
        object nacDam = "NacionalidadDamnificado"; //parametro39
        object domDam = "DomicilioDamnificado"; //parametro40
        object altDam = "AlturaDamnificado"; //parametro41
        object depDam = "DepartamentoDamnificado"; //parametro42
        object lugDam = "LugarDomicilioDamnificado"; //parametro43
        object telDam = "TelefonoDamnificado"; //parametro44
                                               //parametro acusado
        object acu = "Acusado"; //parametro31


        //variable ruta archovs word
        string rutaDocDenuncia = @"C:\Users\Fede Velho\Desktop\Proyecto\ProyectoComisaria\BackEnd\Comisaria\Comisaria\bin\Debug\net8.0-windows\Archivos Word\Denuncia\Denuncia Comun.docx";
        string rutaDocPartePreventivo = @"C:\Users\Fede Velho\Desktop\Proyecto\ProyectoComisaria\BackEnd\Comisaria\Comisaria\bin\Debug\net8.0-windows\Archivos Word\Denuncia\Parte Preventivo.docx";
        string rutaDocCaratula = @"C:\Users\Fede Velho\Desktop\Proyecto\ProyectoComisaria\BackEnd\Comisaria\Comisaria\bin\Debug\net8.0-windows\Archivos Word\Denuncia\Caratula Judicial.docx";


        public Form1()
        {
            InitializeComponent();
            //RUTA DEL ARCHIVO HTML EN EL PROYECTO
            String rutaArchivoHTML = Path.Combine(Application.StartupPath, "C:\\Users\\Fede Velho\\Desktop\\Proyecto\\ProyectoComisaria\\FronEnd\\indexInicio.html");

            //CARGAR EL ARCHIVO HTML EN EL CONTROL WEBVIEW
            webViewInicio.Source = new Uri(rutaArchivoHTML);


            webViewInicio.WebMessageReceived += (sender, e) =>
            {
                string message = e.TryGetWebMessageAsString();
                dynamic data = JsonConvert.DeserializeObject(message);

                //DATOS INICIALES
                sumarioInput = data.numsum;
                añoSumInput = data.añoSum;
                caratulaInput = data.caratula;
                fiscaliaInput = data.fiscalia;
                dependenciaInput = data.dependencia;
                sumarianteInput = data.sumariante;
                secActuacionesInput = data.secActuaciones;
                comisionadoInput = data.comisionado;
                testigoInput = data.testigo;
                
                //DATOS DENUNCIANTE
                nombreInput = data.nombre;
                aliasInput = data.alias;
                nacionalidadInput = data.nacionalidad;
                estadoCivilInput = data.estadoCivil;
                edadInput = data.edad;
                instruccionInput = data.instruccion;
                profesionInput = data.profesion;
                calleInput = data.calle;
                alturaInput = data.altura;
                deptoInput = data.depto;
                ciudadInput = data.ciudad;
                fechaNacInput = data.fechaNac;
                lugarInput = data.lugar;
                documentoInput = data.documento;
                telefonoInput = data.telefono;
                denunciaInput = data.denuncia;
                
                //DATOS DAMIFICADO
                nombreDamInput = data.nombreDam;

                /*aliasDamInput = data.aliasDam;
                nacionalidadDamInput = data.nacionalidadDam;
                estadoCivilDamInput = data.estadoCivilDam;
                edadDamInput = data.edadDam;
                instruccionDamInput = data.instruccionDam;
                profesionDamInput = data.profesionDam;
                domicilioDamInput = data.domicilioDam;
                alturaDamInput = data.alturaDam;
                deptoDamInput = data.deptoDam;
                LugarDomicilioDamInput = data.LugarDomicilioDam;
                fechaNacDamInput = data.fechaNacDam;
                lugarDamInput = data.lugarDam;
                documentoDamInput = data.documentoDam;
                telefonoDamInput = data.telefonoDam;*/

                //DATOS ACUSADO
                nombreAcuInput = data.nombreAcu;

                //PROCESAR DATOS
                
                Funciones();
            };
        }
        private void Funciones()
        {
            try
            {
                //validacion
                Validacion();

                //crear denuncia
                Carpeta();
                Word.Application ObjWord = new Word.Application();

                
                //crear denuncia
                Denuncia(ObjWord);

                //crear parte preventivo
                PartePreventivo(ObjWord);
                //crear caratula
               // Caratula(ObjWord);

                ObjWord.Quit();
                // Liberar los recursos de Word
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ObjWord);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        //funciones
        //VALIDACIONES
        private void Validacion()
        {
            //VALIDACION DEPENDENCIA
            if(dependenciaInput.Trim() == "Cria. Gral Cabrera")
            {
                localidadInput = "Gral. Cabrera";
                departamental = "Juarez Celman";
                return;
            }
            else if (dependenciaInput.Trim() == "Destacamento Carnerillo")
            {
                localidadInput = "Carnerillo";
                departamental = "Juarez Celman";
                return;
            }
            else if (dependenciaInput.Trim() == "Cria. Gral. Deheza"){
                localidadInput = "Gral. Deheza";
                departamental = "Juarez Celman";
                return;
            }
            //VALIDACION TRIBUNALES
            if(fiscaliaInput.Trim() == "1° Turno")
            {
                magistradoInput = "DR. FABRIZIO CENA";
                secretarioInput = "DR. FABRIZIO CENA";
                return;
            }
            else if (fiscaliaInput.Trim() == "2° Turno")
            {
                magistradoInput = "DR. FRANCISCO DI SANTO";
                secretarioInput = "DRA. LAURA OVIDI";
                return;
            }
            else if (fiscaliaInput.Trim() == "3° Turno")
            {
                magistradoInput = "DR. FERNANDO MOINE";
                secretarioInput = "DR. LUCAS ROSALES";
                return;
            }
            else if (fiscaliaInput.Trim() == "4° Turno")
            {
                magistradoInput = "DANIEL PEDRO MIRALLES";
                secretarioInput = "DR. YANINA ALFONSO";
                return;
            }


        }

        //CREAR CARPETA
        private void Carpeta()
        {
            try
            {
                //crear ruta al escritorio
                ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Crear una carpeta en el escritorio
                folderPath = Path.Combine(ruta, "56-070" + "_" + sumarioInput + "-" + añoSumInput);
                Directory.CreateDirectory(folderPath);
            }
            catch (Exception x)
            {
                MessageBox.Show("Error al crear la carpeta: "+x.Message);
            }
        }
        // EDITAR ARCHVI WORD
        public void WordIn(Word.Document Doc, object nombreBookmark, string textoNombre, string parametro)
        {
            try
            {
                Word.Range nombre = Doc.Bookmarks.get_Item(nombreBookmark).Range;
                nombre.Text = textoNombre;
                object rango = nombre;
                Doc.Bookmarks.Add(parametro, ref rango);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error Editar Word, tipo de error: {ex.Message}");
            }

        }
        //CREAR DENUNCIA
        private void Denuncia(Word.Application ObjWord)
        {
            try
            {
                Word.Document Doc = ObjWord.Documents.Open(rutaDocDenuncia);

                // Ingresar datos en el documento
                WordIn(Doc, Nom, nombreInput.ToUpper(), "parametro1");
                WordIn(Doc, ali, aliasInput, "parametro29");
                WordIn(Doc, Nac, nacionalidadInput, "parametro2");
                WordIn(Doc, civ, estadoCivilInput, "parametro3");
                WordIn(Doc, ed, edadInput, "parametro4");
                WordIn(Doc, ins, instruccionInput, "parametro5");
                WordIn(Doc, pro, profesionInput, "parametro6");
                WordIn(Doc, dom, calleInput.ToUpper(), "parametro7");
                WordIn(Doc, alt, alturaInput, "parametro8");
                WordIn(Doc, dep, deptoInput, "parametro9");
                WordIn(Doc, lugDom, ciudadInput, "parametro33");
                WordIn(Doc, lug, lugarInput, "parametro10");
                WordIn(Doc, fec, fechaNacInvertida, "parametro11");
                WordIn(Doc, doc, documentoInput, "parametro11");
                WordIn(Doc, tel, telefonoInput, "parametro12");
                WordIn(Doc, fecd, fechaLargaInput, "parametro16");
                WordIn(Doc, hs, horaInput, "parametro17");
                WordIn(Doc, tes, testigoInput.ToUpper(), "parametro18");
                WordIn(Doc, den, denunciaInput, "parametro28");
                WordIn(Doc, ciu, localidadInput, "parametro14");

                MessageBox.Show("Se creó la denuncia correctamente!");

                // Guardar y cerrar el documento
                string filePath = Path.Combine(folderPath, "Denuncia.docx");
                Doc.SaveAs2(filePath);
                Doc.Close();

                // Liberar los recursos de Word
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Doc);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la denuncia: {ex.Message}");
            }
        }
        //funcion crear caratula
        public void Caratula(Word.Application ObjWord)
        {
            try
            {

                //abrir documento
                Word.Document Doc3 = ObjWord.Documents.Open(rutaDocCaratula);
                WordIn(Doc3, depa, departamental.ToUpper(), "parametro15");
                WordIn(Doc3, ciu, localidadInput.ToUpper(), "parametro14");
                WordIn(Doc3, numSum, sumarioInput, "parametro25");
                WordIn(Doc3, añoSum, añoSumInput, "parametro26");
                WordIn(Doc3, car, caratulaInput.ToUpper(), "parametro27");
                WordIn(Doc3, Nom, nombreInput.ToUpper(), "parametro1");
                WordIn(Doc3, dam, nombreDamInput.ToUpper(), "parametro32");
                WordIn(Doc3, acu, nombreAcuInput.ToUpper(), "parametro31");
                WordIn(Doc3, añoCor, fechaCortaInput, "parametro30");
                WordIn(Doc3, hs, horaInput, "parametro17");
                WordIn(Doc3, sum, sumarianteInput.ToUpper(), "parametro22");
                WordIn(Doc3, secSum, secActuacionesInput.ToUpper(), "parametro23");
                WordIn(Doc3, com, comisionadoInput.ToUpper(), "parametro24");
                WordIn(Doc3, sec, secretarioInput, "parametro21");
                WordIn(Doc3, fisc, fiscaliaInput, "parametro19");
                // Guardar y cerrar el documento
                string filePath2 = Path.Combine(folderPath, "Caratula.docx");
                Doc3.SaveAs2(filePath2);
                Doc3.Close();
                // Liberar los recursos de Word
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Doc3);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error Crear Caratula: {ex.Message}");
            }

        }
        //funcion crae parte preventivo
        public void PartePreventivo(Word.Application ObjWord)
        {
            try
            {
                Word.Document Doc2 = ObjWord.Documents.Open(rutaDocPartePreventivo);
                WordIn(Doc2, ciu, localidadInput, "parametro14");
                WordIn(Doc2, fecd, fechaLargaInput, "parametro16");
                WordIn(Doc2, car, caratulaInput.ToUpper(), "parametro27");
                WordIn(Doc2, numSum, sumarioInput, "parametro25");
                WordIn(Doc2, añoSum, añoSumInput, "parametro26");
                WordIn(Doc2, añoCor, fechaCortaInput, "parametro30");
                WordIn(Doc2, Nom, nombreInput.ToUpper(), "parametro1");
                WordIn(Doc2, ali, aliasInput, "parametro29");
                WordIn(Doc2, Nac, nacionalidadInput, "parametro2");
                WordIn(Doc2, civ, estadoCivilInput, "parametro3");
                WordIn(Doc2, ed, edadInput, "parametro4");
                WordIn(Doc2, ins, instruccionInput, "parametro5");
                WordIn(Doc2, pro, profesionInput, "parametro6");
                WordIn(Doc2, dom, calleInput.ToUpper(), "parametro7");
                WordIn(Doc2, alt, alturaInput, "parametro8");
                WordIn(Doc2, dep, deptoInput, "parametro9");
                WordIn(Doc2, lugDom, ciudadInput, "parametro33");
                WordIn(Doc2, doc, documentoInput, "parametro11");
                WordIn(Doc2, tel, telefonoInput, "parametro12");
                WordIn(Doc2, hs, horaInput, "parametro17");
                WordIn(Doc2, den, denunciaInput, "parametro28");
                WordIn(Doc2, fisc, fiscaliaInput, "parametro19");

                // Guardar y cerrar el documento
                string filePath2 = Path.Combine(folderPath, "Parte Preventivo.docx");
                Doc2.SaveAs2(filePath2);
                Doc2.Close();
                // Liberar los recursos de Word
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Doc2);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error Crear parte preventivo {ex.Message}");
            }

        }
        private void webViewInicio_Click(object sender, EventArgs e)
        {

        }
    }
}
