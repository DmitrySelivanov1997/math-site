![PG Demidov Yaroslavl State University](https://upload.wikimedia.org/wikipedia/ru/2/28/Logo_demidovskiy_universitet.png)
# ЯрГУ им. П.Г.Демидова
## Сайт математического факультета (обновленный)

### Info

Это сайт для матфака ЯрГУ им. П.Г.Демидова 

Любые pull request-ы, содержащие bugfix-ы и новые полезные features приветствуются

### Требования к системе

* Наличие git
* Наличие .Net Core 2.0 или новее
* Установленный PostgreSQL 9.5 или новее

### Информация по установке

* Склонировать `git clone https://github.com/mokeev1995/math-site.git` (если нужна самая последняя версия -- брать из последней rc-ветки)
* Создать базу данных для сайта
  * Открыть `powershell`/`cmd`/`terminal` (что угодно, лишь бы был доступ к консольной утилите dotnet)
  * Перейти в корневой каталог проекта
  * Запустить `dotnet restore`
  * Перейти в `src/MathSite`
  * Поправить `appsettings.{env}.json`, где env -- это может быть dev или этого пункта может не быть вовсе, то есть просто `appsettings.json`
  * Запустить `dotnet ef database update`
* Добавить данные в БД
  * Перейти в powershell/cmd/terminal в каталог проекта
  * Перейти в `src/Seeder`
  * Запустить `dotnet run "CONNECTION_STRING"`, где вместо CONNECTION_STRING будет строка подключения к БД, которую можно взять в appsettings.{env}.json, который был настроен выше.
	Пример: `dotnet run "Server=127.0.0.1;Port=5432;Database=math;User Id=postgres;Password=0;"`
* Перейти в `src/MathSite`
* Запустить `dotnet run`
* И теперь вы можете зайти на сайт. `localhost:5000` и использовать сайт!)

### Contributors

* [Mokeev Andrey](http://mokeev1995.ru) \< andrey@mokeev1995.ru >
* [Devyatkin Andrey](https://vk.com/id16824326)

### Copyright and License

MIT Licence
