### Основной проект написан на ASP.NET Core 7.0 MVC, разбит на папки:     

* DataAccess – содержит паттерн репозитория, данный паттерн демонстрирует механизм DI,    
также используя этот подход, удобно реализовывать модульные тесты.
* Migrations – Содержит каркас базы данных, механизм entity framework.
* Utilitu – Данная папка содержит различные вспомогательные классы.    
* Остальные папки, стандартный набор платформы ASP.NET Core MVC.

#### Чтобы корректно запустить проект, необходимо
1)	В «Appsettings.json» – изменить строку подключения к вашей базе данных.
2)	В консоли проекта прописать «update-database»
3)	Далее запускаем проект, в меню сайта, выбираем «Поставщики» заводим парочку
4)	Далее. Выбираем пункт меню «Заказы» заводим парочку.

После этого можно запустить тесты.   

Тесты реализованы в двух вариантах 
1.	Модульные.
2.	Интеграционные.
