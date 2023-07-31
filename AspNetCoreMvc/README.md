docker build [--no-cache -t] [imageName]:[tag] .
`--no-cache` : Image olu�tururken t�m Layer'lar yeniden olu�tursun.

**bind mount**
docker run -d -p [MyURL]:URLS --name [ContainerName] --mount type=bind,source="[KaydedilecekDosyaYolu]",target="[bindmountYap�lacakDizininYolu]" [imageId]


**volume**

docker volume create [volumeName]

docker run -d -p [MyURL]:URLS --name mycon -v [volumeName]:[Ba�lan�lacakKlas�r] [imageId]
