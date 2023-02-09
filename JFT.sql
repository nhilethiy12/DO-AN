CREATE DATABASE JFTProject

CREATE TABLE PRODUCTDTO(
PRODUCT_ID INT IDENTITY(1,1) PRIMARY KEY,
PRODUCT_NAME NVARCHAR (30),
PRODUCT_IMAGE NVARCHAR (255),
PRICE FLOAT,
QNT INT,
QNT1 INT,
DETAIL NVARCHAR (4000),
BRAND_ID INT NOT NULL
)

GO

CREATE TABLE BRANDDTO (
BRAND_ID INT IDENTITY(1,1) PRIMARY KEY,
BRAND_NAME NVARCHAR (255),
BRAND_IMAGE NVARCHAR (255),
)

CREATE TABLE COLLECTIONSDTO (
COLLECTION_ID INT IDENTITY(1,1) PRIMARY KEY,
COLLECTION_NAME NVARCHAR (255),
BRAND_ID INT NOT NULL,
PRODUCT_ID INT NOT NULL,
PRODUCT_ID2 INT NOT NULL,
PRODUCT_NAME1 NVARCHAR (30),
PRODUCT_NAME2 NVARCHAR (30),
PRICE_PRO1 FLOAT,
PRICE_PRO2 FLOAT,
PRICE FLOAT,
DETAIL NVARCHAR (4000),
COLLECTION_IMAGE NVARCHAR (255),
COLLECTION_IMAGE2 NVARCHAR (255),
)

CREATE TABLE SLIDEDTO(
SLIDE_ID INT IDENTITY(1,1) PRIMARY KEY,
SLIDE_IMAGE NVARCHAR(255) 
)

CREATE TABLE CHECKOUTDTO(
CUSID INT  IDENTITY(1,1) PRIMARY KEY,
FULLNAME NVARCHAR(255),
Email NVARCHAR(255),
ADDRESSCUS NVARCHAR(255),
PHONENUMBER NCHAR(12),
DAYGET DATE,
PRODUCT_IMAGE NVARCHAR(255),
COLLECTION_IMAGE NVARCHAR(255),
COLLECTION_IMAGE2 NVARCHAR(255)
)

CREATE TABLE CONTACTDTO(
CUS_ID INT  IDENTITY(1,1) PRIMARY KEY,
FIRSTNAME NVARCHAR(255),
LASTNAME NVARCHAR(255),
COMPANY_NAME NVARCHAR(255),
CONTENT NVARCHAR(255)
)

CREATE TABLE LOGINADMIN(
AdminId INT  IDENTITY(1,1) PRIMARY KEY,
AdminName NVARCHAR(255),
Password NVARCHAR(255)
)
INSERT INTO LOGINADMIN VALUES ('admin','123abc')
select * from LOGINADMIN


GO

 /*================================PRODUCT========================================== */
INSERT INTO PRODUCTDTO VALUES ('BMW M2 LCI','bmw-M2LCI.png', 3200000, 1,12, 'This M2 benefits from a strong specification including the Harmon/Kardon sound system, M Performance carbon-fibre rear diffAdmin and M Performance ‘Frozen Gold’ wheels. 
In addition, the vehicle has also been tuned by Motech, who fitted a Remus exhaust system with Bluetooth-controllable valves, Motech exclusive EBC two-part front brake discs and Yellowstuff pads, Eibach lowering springs, Motech wheel spacers, and an M2 CS carbon boot lip spoiler. Included with the vehicle is a full complement of BMW handbooks, manuals and service records, the V5 document showing two former keepers, original tool kit, tyre sealant, warranty records, two sets of keys and several invoices for work carried out to the vehicle.', 6)

INSERT INTO PRODUCTDTO VALUES ('Blue Ferrari','ferrari-bluef60.png', 2300000, 1,12, 'The design of the F60 America was inspired by the 1967 Ferrari 275 GTB/4S NART Spider, with the distinctive grille detailing Ferraris 60s. Only 10 Ferrari F60 Americas were produced exclusively for those The brands loyal customer base in the US is equal to the number of Ferrari 275 GTB/4S NARTs produced. The cars exterior is in Blu Nart blue with red decorative lines. This is a set of traditional racing stamps of the Ferrari North American Racing Team (NART). The 60th anniversary logo is placed on both sides of the body. The image of the stylized number 60 with the national flags of Italy and the United States is interlocked, accompanied by the words "1954 - 2014 Ferrari 60 Years in USA". The classic style is also reflected in the anti-roll frame located behind the headrest and the small ducktail spoiler. Customers can choose between a canvas roof or carbon fiber.', 5)
INSERT INTO PRODUCTDTO VALUES ('Lamborghini Aventador','lamborghini-aventador.png', 4560000, 1,12, 'Lamborghini has never let its customers down with the cabin. Opening the door to the Lamborghini Aventador SVJ 2022, you will feel like you are entering another world, where everything belongs to the top class and luxury. The steering wheel of this supercar has a unique 3-spoke horizontal beveled bottom design. The dashboard is carefully invested with modern and eye-catching buttons. Especially, the dashboard is connected to the armrest, when resting the drivers hand, the driver can still easily perform flexible knob turning operations. Its hard not to commend this care. On the seats of the Lamborghini Aventador SVJ 2022, there is a prominent red and white SVJ logo. This is the highlight that distinguishes the SVJ version from other brothers in the Lamborghini family. ', 4)
INSERT INTO PRODUCTDTO VALUES ('Ferari F12 Berlinetta','ferrari-f12berlinetta.png', 3300000, 1,12, 'The interior of the new generation Ferrari F12 Berlinetta supercar is filled with modern equipment. The entire interior of the car is upholstered in high-quality leather and is completely handcrafted. Equipped with a sport steering wheel that integrates many functions and control buttons are arranged around the driver for optimal convenience. The dashboard is equipped with a central display panel that provides parameters about travel speed, engine rpm, coolant temperature, oil temperature and gearbox position... Ferrari F12 Berlinetta 2022 equipped The seats are comfortable and classy. All rows of seats are covered with high-quality leather, smooth and can comfortably relax, fall and stop on your supercar. A classy 2-seater supercar that is completely worthy of the supercar.', 5)
INSERT INTO PRODUCTDTO VALUES ('Porsche 911','posche-911.png', 1990000, 1, 12,'The 911 is Porsches flagship car, the car that made the German automaker famous, with its timeless design, sporty driving feel and speed. 911 is always on the wish list of many car lovers around the world.
Power: 283 kW (385 PS) Maximum torque: 450 Nm Acceleration from 0 - 100 km/h (0 - 62 mph): 4.2 seconds Top speed: 293 km/h Combined fuel consumption (litres/100km): 13.2 (NETC) - 9.4 (NEDC) CO2 emissions (g/km): 215', 2)

INSERT INTO PRODUCTDTO VALUES ('Audi R8','audi-r8.png', 2000000, 1, 12,'Super sports car model Audi R8 launched in 2006, so far has gone through two generations. The first is the Type 42 sold from 2006 to 2015, the second generation is the Type 4S sold from 2015 to the present.
After being facelifted in 2018, the Audi R8 continues to be improved with a number of functions and technologies. The latest version of the Audi R8 is divided into two models, the Audi R8 Coupe V10 and the Audi R8 Spyder (convertible).
Audi R8 is a popular sports car worldwide since its launch. This is also the model that has stood side by side with Iron Man in many Marvel superhero blockbuster products. As of 2016, global sales of the Audi R8 reached nearly 30,000 units.', 3)

INSERT INTO PRODUCTDTO VALUES ('Ferrari Enzo','ferari-enzo.png', 5100000, 1,12, 'The Enzo Ferrari is a 12-cylinder Ferrari supercar named after the companys founder, Enzo Ferrari. It was built in 2003 using Formula 1 technology such as carbon fiber bodywork, F1-style sequential shift transmission, and carbon ceramic brake discs. Other technologies not used in F1 cars such as active aerodynamics are also used in the car. When the vehicle reaches 300 km/h (186 mph), downforce will reach 775 kg (1709 lb) and the rear wing will be computer controlled to maintain this force.
Enzos V12 engine is the first in a new generation of Ferrari engines. It is based on the V8 type construction used for sister company Maseratis Quattroporte, both with the same construction and 104 mm bore spacing. This design replaces the previous structures on the V12 and V8 engines installed in most other contemporary Ferrari cars. The 2005 F430 was the second Ferrari car to be fitted with this new engine.', 5)

INSERT INTO PRODUCTDTO VALUES ('Lamborghini B&B','lamborghini-bb.png', 4700000, 1,12, 'The era of the Lamborghini Aventador has finally come to an end after a decade of storming the globe. The last Lamborghini Aventador of the LP 780-4 Ultimae version announced not long ago has found its owner after being auctioned off recently. Spending that huge amount of money, buyers not only get to own the ultimate Lamborghini Aventador but also get an NFT 1:1 copy of the coupe co-developed by the Italian brand with 2 artists Krista Kim and Steve Aoki as well. like INVNT GROUP. Last but not least, Lamborghini Aventador owners have access to the most VIP perks possible from the Italian marque including meeting the artists who helped them build the final Aventador, being informed. as well as previews of future limited edition Lamborghinis, being invited to participate in local Lamborghini dealership activities and visiting the Lamborghini museum.', 4)
INSERT INTO PRODUCTDTO VALUES ('Porsche Speedster','porsche-speedster.png', 3500000, 1,12, 'The concept car presented to celebrate the sports car makers 70th anniversary will be produced as a limited special edition: Porsche has decided to start production of the purebred Porsche 911 Speedster in the second half of the year. In early 2019. The two-seater model will be produced exactly 1,948 units. This number is reminiscent of the Porsche 356 “Number 1” which received its license on 8 June 1948. In Paris, Porsche presented the second Speedster concept car this year. The new model is covered with Guards Red exterior paint inspired by the 1988 911 Speedster version of the G generation. The new 21-inch 5-spoke wheel design combined with the black leather interior creates a vehicle. Sophisticated and sporty. Dreams come true: The 911 Speedster concept is already in service, originally introduced on 8 June 2018 at Zuffenhausen as a “Heritage” version, and will now entered production in 2019. The model was developed at the Porsche Motorsport Division in Weissach in collaboration with Style Porsche and Porsche Exclusive Manufaktur. The future 911 Speedster, based on the 991 version, will be the first to be equipped with the new Heritage Design Packages. Exclusive equipment from Porsche Exclusive extends the personalization further in the 911 range.', 2)
INSERT INTO PRODUCTDTO VALUES ('Audi Q8 Revealed','audi-q8revealed.png', 2200000, 1, 12,'Audi has revealed a new luxury SUV called the Q8, aiming to attract customers who are ditching passenger cars for bigger vehicles. The Volkswagen luxury automotive lineups 2019 Audi Q8 debuted this week at the Audi Brand Summit event held in Shenzhen, China, now one of the worlds largest luxury car markets. The five-passenger Q8, which was revealed in concept form at the Detroit auto show in 2017, is wider than the Audi Q7 but also sits lower. Designers aimed for a coupe-like feel. The Audi Q8 is expected to hit U.S. dealerships in late 2018. The company did not reveal pricing. The Q8 serves as a guidepost of Audis SUV design direction on both the exterior and the interior. Notable features include an octagonally shaped grille and large air inlets. Inside, Audi overhauled its infotainment operating system. Now, for instance, a driver or passenger will feel a little tactile response when they touch a button on the screen or hear a sound. Admins can personally configure the system to improve usability. Other connectivity features include wireless smartphone charging capability.', 3)
INSERT INTO PRODUCTDTO VALUES ('Mercedes-Benz SLS','mercedes-sls.png', 1700000, 1, 12,'The new Mercedes SLS AMG supercar is produced with the meaning of saying goodbye to the SLS line. Like other models of the famous "Three-pointed Star" brand, SLS AMG possesses definitive lines and is full of generosity. The special highlight of the car is the unique and new bird-shaped door opening that has attracted the attention of car lovers around the world. Exterior of the new Mercedes SLS AMG version has many details made from carbon fiber: Long clawed bonnet; Large size spoiler; Rearview mirror; The front bumpers splitter, etc. The brake system has also been upgraded for more performance. New sports style wheels made of super light alloy. The new Mercedes SLS AMG has an interior compartment designed with a harmonious combination of modernity and luxury. 3-spoke sport steering wheel wrapped in Alcantara material. Besides, the mixture of silver color of chrome and stainless steel materials along with glossy black color of carbon material helps to make the car interior space more luxurious but also very strong.', 1)

INSERT INTO PRODUCTDTO VALUES ('Audi R8','audi-r8.png', 1570000, 1, 12,'The new Audi R8 2022 version possesses a luxurious and aggressive appearance but also comes with the companys most modern equipment.
If you are a true fan of sports cars, you should definitely not ignore the latest news about the Audi R8 2022. About the interior of the R8 V10 supercar, it is still the most popular. the design of the previous version dso.
However, the steering wheel and dashboard are carefully designed and cared for by Audi, making people interested at first sight.
In addition, Audi also adds interior color options such as silver/gray thread, brown/gray thread or black/blue thread for Admins to freely choose according to personal preferences.
In particular, in the most advanced R8 V10 Plus version, the interior will be equipped with an Alcantara combination leather interior package, carbon fiber decorative panels with extremely luxurious and attractive Mercato blue details.', 3)

INSERT INTO PRODUCTDTO VALUES ('Sesto Elemento','lamborghini-SestoElemento.png', 6100000, 1,12,'You can temporarily forget about the hybrid Lamborghini Sían (petrol-electric powertrain) that the company plans to show at the upcoming Frankfurt motor show because we will go back in time, back. 2010 Paris Motor Show exhibition with the Lamborghini Sesto Elemento line. Meaning "sixth element" in Italian, Sesto Elemento uses the element carbon to manufacture – the sixth element on the periodic table. Thanks in part to the design made from carbon fiber, the Lamborghini Sesto Elemento version weighs only 2,202 pounds, 137 pounds lighter than the Mazda MX-5 Miata (meaning the weight of this rare car is only about 999kg). Mazda needs a 4-cylinder, 2.0-liter engine that produces 181 horsepower. And the Lamborghini Sesto Elemento uses a 5.2-liter V10 engine, producing 570 horsepower. With a full-time 4-wheel drive system, Lamborghini Sesto Elemento takes only 2.5 seconds to accelerate from 0-100km / h and then can reach a maximum speed of 320km / h. This model is 0.3 seconds faster than the Lamborghini Sían and moreover, the lighter weight of the Sían series is the strong point of the Lamborghini Sesto Elemento.', 4)
INSERT INTO PRODUCTDTO VALUES ('Porche Panamera','posche-panamera.png', 2900000, 1, 12,'The Porsche Panamera 2022 is a perfect sedan with a modern and improved sporty Porsche style. The car line impresses right from the simplest lines with the strong and strong style of Porsche. Surely Porsche Panamera 2022 will be the car that brings "huge" sales for this car company. The Porsche Panamera 2022 really has boundless power from the 4.0L V8 engine to conquer car enthusiasts. The new generation of cars has been spectacularly improved, conquering many customers at first sight. Porsches Panamera 2022 is predicted to have "extreme" sales. Many customers think that the interior of the Porsche Panamera 2022 is "old wine in a new bottle". However, the essence of the new generation Panamera still needs a hint of Porsche taste. The car seems to have done a good job of combining the identity of this German automaker with new things that have been improved. The dashboard of the car is tilted forward, very convenient to the Admins steering wheel as well as the driver. have better vision. A mechanical rev counter is designed to be placed in the center of the instrument cluster, they are "escorted" by very modern information displays, the perfect combination of tradition and innovation. Soft leather steering wheel for a great driving feeling. At the same time, the gear lever is also very compact, just within reach of Vietnamese Admins, so when manipulating and creating a feeling of being extremely active.', 2)
INSERT INTO PRODUCTDTO VALUES ('Mercedes AMG C63','mercedes-AMG-C63.png', 1000000, 1, 12,'Unlike many other mass-produced models, the Mercedes AMG C63 S 2021 is one of the companys "rare goods" box cars with limited production. With unique, new and extremely attractive characteristics, the Mercedes-AMG C63 2021 creates a fever of hunting for "rare goods" never seen on the market. Hurry up and pick up a 2017 Mercedes AMG C63 S as soon as possible lest you regret it! So why should people focus their attention on the Mercedes-AMG C63 2021? Why do people like limited things and not other mass production models? It is because of originality and uniqueness! Despite possessing a small price, the Mercedes-AMG C63 2021 has received special attention from the discerning car player. This proves the great attraction of the Mercedes-AMG C63 2021 and further proves the perfection in the exterior, the comfort in the interior and the excellence in the performance of this car! The first point that is easy to notice and also attracts the most Admins from the very beginning is the exterior of the Mercedes-AMG C63 2021. The AMG sports bonnet of this model is especially impressive with 2 roads. embossed ribs, completely different from other models of the company. The grille is designed with 2 AMG spokes in silver chrome with a 3-pointed star in the middle & the AMG logo showing a modern, elegant, sporty and luxurious look. The Edition 1 decal is affixed to the side of the vehicle and the V8 BITURBO badge on the side clearly indicates the one-of-a-kind version and engine of this character-filled vehicle.', 1)

/*================================BRAND========================================== */
INSERT INTO BRANDDTO VALUES ('Mercedes','Brand-Mercedes.png')
INSERT INTO BRANDDTO VALUES ('Porsche','Brand-Posche.png')
INSERT INTO BRANDDTO VALUES ('Audi','Brand-Audi.png')
INSERT INTO BRANDDTO VALUES ('Lamborghini','Brand-Lamborghini.png')
INSERT INTO BRANDDTO VALUES ('Ferari','Brand-Ferari.png')
INSERT INTO BRANDDTO VALUES ('BMW','Brand-BMW.png')

/*================================COLLECTION========================================== */
INSERT INTO COLLECTIONSDTO VALUES ('SUMMER', 5,4,7,'Ferari F12 Berlinetta',' Ferrari Enzo',3300000,5100000, 7000000,'ABC', 'ferrari-f12berlinetta.png', 'ferari-enzo.png')
INSERT INTO COLLECTIONSDTO VALUES ('SPRING', 1,11,15,'Mercedes-Benz SLS',' Mercedes AMG C63',3300000,5100000, 7000000,'ABC', 'mercedes-sls.png', 'mercedes-AMG-C63.png')



/*================================SLIDE========================================== */
INSERT INTO SLIDEDTO VALUES ('Slide 1.png')
INSERT INTO SLIDEDTO VALUES ('Slide 2.png')
INSERT INTO SLIDEDTO VALUES ('Slide 3.jpeg')
INSERT INTO SLIDEDTO VALUES ('Slide 4.png')
INSERT INTO SLIDEDTO VALUES ('Slide 5.png')
/*================================SLIDE========================================== */

SELECT *FROM PRODUCTDTO
SELECT *FROM BRANDDTO
SELECT *FROM COLLECTIONSDTO
SELECT *FROM SLIDEDTO
SELECT *FROM CHECKOUTDTO
SELECT *FROM CONTACTDTO

