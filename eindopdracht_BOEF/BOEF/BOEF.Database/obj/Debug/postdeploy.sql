-- Beest types
insert into BeestType([Type]) values ('Boerderij');
insert into BeestType([Type]) values ('Woestijn');
insert into BeestType([Type]) values ('Jungle');
insert into BeestType([Type]) values ('Sneeuw');

-- Beest images
insert into BeestImage([Name], [ImagePath]) values ('Aap', '~\Images\aap.png');
insert into BeestImage([Name], [ImagePath]) values ('Bever', '~\Images\Bever.png');
insert into BeestImage([Name], [ImagePath]) values ('Doggo', '~\Images\Doggo.png');
insert into BeestImage([Name], [ImagePath]) values ('Donkey', '~\Images\Donkey.png');
insert into BeestImage([Name], [ImagePath]) values ('Duck', '~\Images\Duck.png');
insert into BeestImage([Name], [ImagePath]) values ('IJsbeer', '~\Images\IJsbeer.png');
insert into BeestImage([Name], [ImagePath]) values ('Kat', '~\Images\Kat.png');
insert into BeestImage([Name], [ImagePath]) values ('Kip', '~\Images\Kip.png');
insert into BeestImage([Name], [ImagePath]) values ('Koe', '~\Images\Koe.png');
insert into BeestImage([Name], [ImagePath]) values ('Kuiken', '~\Images\Kuiken.png');
insert into BeestImage([Name], [ImagePath]) values ('Leeuw', '~\Images\Leeuw.png');
insert into BeestImage([Name], [ImagePath]) values ('Olifant', '~\Images\Olifant.png');
insert into BeestImage([Name], [ImagePath]) values ('Pingwing', '~\Images\Pingwing.png');
insert into BeestImage([Name], [ImagePath]) values ('Varken', '~\Images\Varken.png');
insert into BeestImage([Name], [ImagePath]) values ('Zebra', '~\Images\Zebra.png');
insert into BeestImage([Name], [ImagePath]) values ('Zeehond', '~\Images\Zeehond.png');
insert into BeestImage([Name], [ImagePath]) values ('Pingwing', '~\Images\Pingwing.png');
insert into BeestImage([Name], [ImagePath]) values ('notfound', '~\Images\notfound.jpg');

-- Beest
insert into Beest([Name],[Type],[Prijs],[Image]) values('Aap', 'Jungle', '32', '1');
insert into Beest([Name],[Type],[Prijs],[Image]) values('Olfiant', 'Jungle', '102', '12');
insert into Beest([Name],[Type],[Prijs],[Image]) values('Zebra', 'Jungle', '54', '15'); 
insert into Beest([Name],[Type],[Prijs],[Image]) values('Leeuw', 'Jungle', '65', '11'); 
insert into Beest([Name],[Type],[Prijs],[Image]) values('Hond', 'Boerderij', '12', '3');
insert into Beest([Name],[Type],[Prijs],[Image]) values('Ezel', 'Boerderij', '25', '4'); 
insert into Beest([Name],[Type],[Prijs],[Image]) values('Koe', 'Boerderij', '35', '9'); 
insert into Beest([Name],[Type],[Prijs],[Image]) values('Eend', 'Boerderij', '5', '5'); 
insert into Beest([Name],[Type],[Prijs],[Image]) values('Kuiken', 'Boerderij', '2', '10'); 
insert into Beest([Name],[Type],[Prijs],[Image]) values('Pinguïn', 'Sneeuw', '45', '17'); 
insert into Beest([Name],[Type],[Prijs],[Image]) values('IJsbeer', 'Sneeuw', '75', '6');
insert into Beest([Name],[Type],[Prijs],[Image]) values('Zeehond', 'Sneeuw', '52', '16'); 
insert into Beest([Name],[Type],[Prijs],[Image]) values('Kameel', 'Woestijn', '87', '18'); 
insert into Beest([Name],[Type],[Prijs],[Image]) values('Slang', 'Woestijn', '36', '18'); 

-- Accessoire images
insert into AccessoireImage([Name], [ImagePath]) values('notfound', '~\Images\notfound.jpg')

-- Accessoire
insert into Accessoires([Name],[Price],[IdBeest], [Image]) values('Banaan', '5', '1', '1');
insert into Accessoires([Name],[Price],[IdBeest], [Image]) values('Zadel', '22', '3', '1');
insert into Accessoires([Name],[Price],[IdBeest], [Image]) values('Zweep', '12', '4', '1');
insert into Accessoires([Name],[Price],[IdBeest], [Image]) values('Krukje', '25', '4', '1');
insert into Accessoires([Name],[Price],[IdBeest], [Image]) values('Bal', '10', '5', '1');
insert into Accessoires([Name],[Price],[IdBeest], [Image]) values('Dansschoenen', '35', '10', '1');
insert into Accessoires([Name],[Price],[IdBeest], [Image]) values('Bal', '10', '12', '1');

GO
