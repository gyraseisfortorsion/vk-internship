# vk-internship

В качестве UI для взаимодействия я использовал swagger. В папке migrations есть миграции EF, они должны создать дб на вашем постгре сервере. 
Если миграция по каким то причинам не будет работать, попрошу вас создать новую миграцию:

.NET Core CLI (Mac users)
```
$ dotnet ef migrations add migration
$ dotnet ef database update
```
Важно! в терминале вы должны находится в vk-internship2/vk-internship2

Visual Studio (Package manager console/PowerShell)
```
Add-Migration migration
Update-Database
```

Для чистоты решения я решил не добавлять юзеров, в качестве проверки вы можете симулировать POST запросы на swagger, ну и дальше уже проверить остальные методы 
