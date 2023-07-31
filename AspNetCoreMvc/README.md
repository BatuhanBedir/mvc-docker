docker build [--no-cache -t] [imageName]:[tag] .
`--no-cache` : Image oluþtururken tüm Layer'lar yeniden oluþtursun.

**bind mount**
docker run -d -p [MyURL]:URLS --name [ContainerName] --mount type=bind,source="[KaydedilecekDosyaYolu]",target="[bindmountYapýlacakDizininYolu]" [imageId]


**volume**

docker volume create [volumeName]

docker run -d -p [MyURL]:URLS --name mycon -v [volumeName]:[BaðlanýlacakKlasör] [imageId]
