docker build [--no-cache -t] [imageName]:[tag] .

`--no-cache` : Image olustururken tum Layer'lar yeniden olustursun.

**bind mount**

docker run -d -p [MyURL]:URLS --name [ContainerName] --mount type=bind,source="[KaydedilecekDosyaYolu]",target="[bindmountYapilacakDizininYolu]" [imageId]


**volume**

docker volume create [volumeName]

docker run -d -p [MyURL]:URLS --name mycon -v [volumeName]:[BaglanilacakKlas�r] [imageId]

**ENV**

env belirtilmezse ->production -->.exe calistirildiginda
localhost -->development

docker run -p [myport]:[port] --env ASPNETCORE_ENVIRONMENT=Development --name [cont.name] [Imageid]

appsettingjson  i�inde tanimlanmis degiskenleri ezmek icin de kullanilir

exp: 

docker run -p [myport]:[port] --env MySqlCon='uzak sunucu veritaban� yolu' --name [cont.name] [Imageid]
