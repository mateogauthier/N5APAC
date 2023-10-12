Agregando un service.AddScoped<> con la logica de estudiante en el program.cs

Porque AddScoped garantiza una sola instancia de la clase por request.

AddSingleton instanciaria 1 sola para todo el programa

AddTransient instancia y mantiene a la clase a lo largo de las requests

