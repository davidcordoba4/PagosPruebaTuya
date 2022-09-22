Herramientas utilizadas:
Postman for Windows
Version 9.31.9

Visual Studio Community 2019
Microsoft Sql Server v18.8
Microsoft Sql Server 2019 Express Edition

Version SDK de .NET Core:
Version:   3.1.101

El archivo de la solución se encuentra en la ruta: PagosPruebaTuya\WebAPIPagosTUYA\WebAPIPagosTUYA.sln

Paquetes Nuget instalados y utilizados con respecto a EntityFramework:
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools

Proyecto de Inicio: WebAPIPagosTUYA

Hacer Debug Seleccionando en el boton de Play para iniciar Debug en lugar de IIS Express, seleccionar WebAPIPagosTUYA

Se sube en repositorio backup BD:
Backup PagosPruebaTuya.bak

Coleccion PostMan Evidencias Consumo Metodos Endpoint REST Servicio De Pago:
PeticionesWebAPIPagosTuya.postman_collection.json

Arquitectura Implementada - 4 Capas:
Capa Expuesta API - WebAPIPagosTUYA
Capa de Negocio - WebAPIPagosTUYA.Core
Capa de Modelo o Entidades - WebAPIPagosTUYA.Entities
Capa de Repositorio o Acceso a Datos - WebAPIPagosTUYA.Repositories

Inyeccion de Dependencias en Metodo ConfigureServices archivo :
PagosPruebaTuya\WebAPIPagosTUYA\Startup.cs

Archivo Evidencias Consumo Metodos Endpoint REST Servicio De Pago:
Evidencias Consumo Metodos Endpoint REST Servicio De Pago.docx

El request nombrado CreateFactura en la colección PostMan al ser consumido devuelve un JSON con los siguientes campos:
nroFactura, total donde nroFactura corresponde al número de factura asignado para la factura enviada a crear y el campo total corresponde al totalizado de productos asociados

El request nombrado CreatePedido en la colección PostMan crea el pedido correspondiente, dentro de sus campos a ser enviados se debe enviar el nroFactura devuelto por CreateFactura.


