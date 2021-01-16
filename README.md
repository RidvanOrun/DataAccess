# DataAccessSolution
Bu projede "DataAccessSolution" başlığı altında örneklerle Entity Framework teknolojisi anlatılmıştır. 

[**Lab1**](https://github.com/RidvanOrun/DataAccessSolut-onEF/tree/master/Lab1_DbFirstExamplesLinqTo) => DataBase First yönetimin ve Linq To temel sorguları anlatılmıştır.

[**Lab2**](https://github.com/RidvanOrun/DataAccessSolut-onEF/tree/master/Lab_2DbFirstExamplesMixed) => Database First yönetimi ile karışık Linq To örnekler yapılmıştır. 

[**Lab3**](https://github.com/RidvanOrun/DataAccessSolut-onEF/tree/master/Lab3_CodeFirst_PhoneBook) => Code First yönetemi ile "Telefon Rehberi" uygulaması yapılmıştır.

[**Lab4**](https://github.com/RidvanOrun/DataAccessSolut-onEF/tree/master/Lab4_CodeFirst_NorthwindMigration) => Code First yönetemi ile NorthWind database i ayağa kaldırılmıştır.

Bu teknolojinin tam olarak anlaşılması için öncelikli Object Relational Mapping'in  ve devamında Entity Framework'ün 3 temel yeteneği olan Database First, Code First ve Model First yöntemlerinin anlaşılması gerekmektedir.

## Object Relational Mapping (ORM);
![Image of ORM](https://gblobscdn.gitbook.com/assets%2F-MO29WVIoUuc3uBPrU4f%2F-MOUTWRxdN1GWFPVU-yc%2F-MOUWuNxwI9TSP1Klac1%2FORM.jpg?alt=media&token=4e750631-0c7d-48a7-aaa8-56fe928ff7c3)

  Veritabanı ile uygulama arasında köprü görevi görür. Veri tabanındaki table'ları class'lara, kolonları property'lere , kayıtları objelere dönüştürerek uygulmanın direkt olarak veritabanına erişmesine gerek kalmadan tüm veri tabanı işlemlerini gerçekleştiren bir yapıdır. ORM ler ADO.NET prensipleri ile çalışırlar.
Tüm dillerin kendilerine göre ORM Ferameworkleri bulunmaktadır.

## Entity Framework;
![Image of EF](https://gblobscdn.gitbook.com/assets%2F-MO29WVIoUuc3uBPrU4f%2F-MO7ZrMg_nDNetG8obIg%2F-MO7_HAGRKwiPo2_rLtI%2FEntityFramework.png?alt=media&token=2dd2d1f2-0be8-49f9-bd1c-e8f95120e604)

  Veri tabanındaki table'ları class'lara, kolonları property'lere , kayıtları objelere dönüştürerek uygulmanın direkt olarak veritabanına erişmesine gerek kalmadan tüm veri tabanı işlemlerini gerçekleştirir. Böylece veritabanındaki işlemler SQL kodları yazılmadan Linq isimli sorgular ile kolayca yapılabilir.Entity Framework bir ORM aracıdır ve  Ado.net mantığı ile çalışır. 

Entity Framework'un yetenekleri Database First, Code First, Model First olmak üzere 3 farklı biçimde uygulanabilmektedir.

  Yukarıda bahsettiğim teknolojileri daha iyi anlamak için gitbook hesabımdaki çalışmamı inceleyebilirsiniz. https://ridvanorun.gitbook.io/entity-framework/
