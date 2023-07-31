docker build [--no-cache -t] [imageName]:[tag] .

`--no-cache` : Image olustururken tum Layer'lar yeniden olustursun.

**bind mount**

docker run -d -p [MyURL]:URLS --name [ContainerName] --mount type=bind,source="[KaydedilecekDosyaYolu]",target="[bindmountYapilacakDizininYolu]" [imageId]


**volume**

docker volume create [volumeName]

docker run -d -p [MyURL]:URLS --name mycon -v [volumeName]:[BaglanilacakKlasör] [imageId]
