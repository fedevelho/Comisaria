

function sendData() {
    //SUMARIO
    var numsum = document.getElementById("numSumarioInput").value;
    var añoSum = document.getElementById("añoSumInput").value;
    var caratula = document.getElementById("caratulaInput").value;
    var fiscalia = document.getElementById("fiscaliaInput").value;
    var dependencia = document.getElementById("localidadInput").value;
    //var fecha = document.getElementById("fechaInput").value;
    //var fechaLarga = document.getElementById("fechaInput").value = new Date().toLocaleDateString('es-ES', { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' }); //cambia la fecha a la larga
    //var hora = document.getElementById("horaInput").value;
    var sumariante = document.getElementById("sumarianteInput").value;
    var secActuaciones = document.getElementById("secActuacionesInput").value;
    var comisionado = document.getElementById("comisionadoInput").value;
    var testigo = document.getElementById("testigoInput").value;
    
    //DENUNCIANTE
    var nombre = document.getElementById("nombreInput").value;
    var alias = document.getElementById("aliasInput").value;
    var nacionalidad = document.getElementById("nacionalidadInput").value;
   var estadoCivil = document.getElementById("civilInput").value;
   var edad = document.getElementById("edadInput").value;
   var instruccion = document.getElementById("instruccionInput").value;
   var profesion = document.getElementById("profesionInput").value;
    var calle = document.getElementById("domicilioInput").value;
    var altura = document.getElementById("alturaInput").value;
    var depto = document.getElementById("deptoInput").value;
    var ciudad = document.getElementById("LugarDomicilioInput").value;
    var fechaNac = document.getElementById("fechaNacInput").value;
    var lugarNac = document.getElementById("lugarInput").value;
    var documento = document.getElementById("documentoInput").value;
    var telefono = document.getElementById("telefonoInput").value;
    var denuncia = document.getElementById("editor").innerText;

    //DATOS DAMNIFICADO
    var nombreDam = document.getElementById("nombreDamInput").value;
    /*var aliasDam = document.getElementById("aliasDamInput").value;
    var nacionalidadDam = document.getElementById("nacionalidadDamInput").value;
   var estadoCivilDam = document.getElementById("civilDamInput").value;
   var edadDam = document.getElementById("edadDamInput").value;
   var instruccionDam = document.getElementById("instruccionDamInput").value;
   var profesionDam = document.getElementById("profesionDamInput").value;
   var domicilioDam = document.getElementById("domicilioDamInput").value;
   var alturaDam = document.getElementById("alturaDamInput").value;
   var deptoDam = document.getElementById("deptoDamInput").value;
   var LugarDomicilioDam = document.getElementById("LugarDomicilioDamInput").value;
   var fechaNacDam = document.getElementById("fechaNacDamInput").value;
    var lugarDam = document.getElementById("lugarDamInput").value;
    var documentoDam = document.getElementById("documentoDamInput").value;
    var telefonoDam = document.getElementById("telefonoDamInput").value;*/

    //DATOS ACUSADO
    var nombreAcu = document.getElementById("nombreAcuInput").value;
    
    
    //PASAR LOS DATOS A C#
    window.chrome.webview.postMessage(JSON.stringify({ 
        //DATOS SUMARIO ENVIAR
        numsum: numsum,
        añoSum: añoSum,
        caratula: caratula, 
        fiscalia: fiscalia, 
        dependencia: dependencia,
        sumariante: sumariante,
        secActuaciones: secActuaciones,
        comisionado: comisionado,
        testigo: testigo,
        
        //DATOS DENUNCIANTE ENVIAR
        nombre: nombre,
        alias: alias, 
        nacionalidad: nacionalidad, 
        estadoCivil: estadoCivil, 
        edad: edad, 
        instruccion: instruccion, 
        profesion: profesion,
         calle: calle,
         altura: altura,
         depto: depto,
         ciudad: ciudad,
         fechaNac: fechaNac,
         lugarNac: lugarNac,
         documento: documento,
         telefono: telefono,
         denuncia: denuncia,
         
         //DATOS DAMNIFICADO
         nombreDam: nombreDam,
         /*aliasDam: aliasDam,
         nacionalidadDam: nacionalidadDam, 
         estadoCivilDam: estadoCivilDam,
         edadDam: edadDam,
         instruccionDam: instruccionDam,
         profesionDam: profesionDam,
         domicilioDam: domicilioDam,
         alturaDam: alturaDam,
         deptoDam: deptoDam,
         LugarDomicilioDam: LugarDomicilioDam,
         fechaNacDam: fechaNacDam,
         lugarDam: lugarDam,
         documentoDam: documentoDam,
        telefonoDam: telefonoDam*/
       //DATOS ACUSADO
       nombreAcu: nombreAcu
       
        }));
}


function mostrarResumen() {
  // Obtiene el valor del input con id "inputSummary"
  var testigoDenunciaInput = document.getElementById("InputWitness").value;

  // Asigna el valor obtenido al contenido del elemento con id "datosMostrados"
  var testigoDenunciaElement = document.getElementById("datosMostrados");
  testigoDenunciaElement.innerText = testigoDenunciaInput;
}




//function changer profiel image
function changerSummaryImg() {
  document.getElementById("imgProfile").src = 'Iconos/sumariante.png';
}
function changerSecSummaryImg() {
  document.getElementById("imgProfile").src = 'Iconos/policia (6).png';
}
function changerCommissionerImg() {
  document.getElementById("imgProfile").src = 'Iconos/coche-de-policia.png';
}
function changerWitnessImg(){
  document.getElementById("imgProfile").src = "Iconos/civil.png"
}


//funcion botones del editor de texto
function convertirMayuscula(){
    var texto = document.getElementById("texto");
  var inicio = texto.selectionStart;
  var fin = texto.selectionEnd;
  var textoSeleccionado = texto.value.substring(inicio, fin);
  texto.value = texto.value.substring(0, inicio) + textoSeleccionado.toUpperCase() + texto.value.substring(fin);
}
function convertirMinuscula() {
    var texto = document.getElementById("texto");
    var inicio = texto.selectionStart;
    var fin = texto.selectionEnd;
    var textoSeleccionado = texto.value.substring(inicio, fin);
    texto.value = texto.value.substring(0, inicio) + textoSeleccionado.toLowerCase() + texto.value.substring(fin);
  }
  

  function convertirNegrita() {
    var texto = document.getElementById("texto");
    var inicio = texto.selectionStart;
    var fin = texto.selectionEnd;
    var textoAntes = texto.value.substring(0, inicio);
    var textoSeleccionado = texto.value.substring(inicio, fin);
    var textoDespues = texto.value.substring(fin);
    texto.value = textoAntes + '<span class="negrita">' + textoSeleccionado + '</span>' + textoDespues;
}
