- Ejecutar el Script 01-Create-Master-Database.sql para crear la Base de Datos MasterDb
- Ejecutar el Script 02-Create-Master-Tables.sql para crear las tablas de MasterDb
- Registrar una Organización => Se creará la Base de Datos cuyo nombre representa el TenantId
- Registrar un Usuario asociándolo a la Organizacion creada previamente
- Autenticar el usuario para obtener un Token de Acceso
- Realizar CRUD de Productos:
	=> QueryString slugTenant: El nombre de la Base de Datos creada para la Organización
	- AccessToken: Establecerlo en el Header de Autorización de tipo Bearer