# ProjektiDataSecurity
  Puna e bere ne projekt ka qene e ndare, secili nga 3 koleget kemi pasur qe te implementojme kodin per ndonjeren nga komandat e dhena.
Kemi pasur te zhvillojme programin i cili enkripton dhe dekripton me ane te komandave: Caesar, Vigenere dhe Rail-Fence, sipas pershkrimeve
te dhena ne kerkesat e projektit.
 1. Komanda e Cezarit është një nga komandat më të hershme dhe më të thjeshta. Është komanda tek e cila me anëntë zëvendësimit që e bëjmë secila shkronjë zhvendosët për një numër të caktuar vendesh poshtë apo lartë(enkriptim ose dekriptim).P.sh me zhvendosje një A zhvendoset në B, B në C.
 2. Komanda Vigenere eshte e ngjajshme e komanden Cezar, e cila perdoret per enkriptim te teksteve me ermbajtje alfabetike, por zhvendosja tek kjo komande nuk behet e njejte per secilen shkronje, or secila shkronje ka zhvendosje te ndryshme.
 3. Komanda Rail-Fence poashtu eshte komande per enkriptim, e cila tekstin te cilin deshirojme ta enkriptojme e vendos ne kolona te nje matrice, dhe enkriptimi i kesaj fjale behet thjeshte duke e lexuar ne drejtim te rreshtave. Nese teksti nuk e mbushe tere matricen atehere 
hapsirat e mbetura do te mbushen me ndonje shkronje te cfardoshme.
 File-i perfundimtar eshte $ds.cpp, ndersa file-at tjere jane puna e kolegeve veq e veq per shkak qe te mos kishim ngaterresa.
Kodi eshte shkruar vazhdimisht por per shkak te perdorimit te argumenteve na eshte dashur qe ne moment te fundit ta nderrojme kodin.

Udhezimi mbi ekzekutimin dhe foto nga ekzekutimi i komandave me shembuj:

![Ekzekutimi](https://user-images.githubusercontent.com/58752918/77952313-be9b5580-72cb-11ea-9e23-108bbfbf692e.png)

1.Cezar-Enkriptimi
![CezarE](https://user-images.githubusercontent.com/58752918/77952488-08843b80-72cc-11ea-8d4f-154656d5055c.png)
Cezar-Dekriptimi
![CezarD](https://user-images.githubusercontent.com/58752918/77952490-091cd200-72cc-11ea-88c6-20a68e371e85.png)

2.Vigenere-Enkriptimi
![VigenereE](https://user-images.githubusercontent.com/58752918/77952515-146ffd80-72cc-11ea-8459-484e548ccd64.png)
Vigenere-Dekriptimi
![VigenereD](https://user-images.githubusercontent.com/58752918/77952516-15089400-72cc-11ea-9496-ed712fecb056.png)

3.Rail-Fence Enkriptimi
![RailFenceD](https://user-images.githubusercontent.com/58752918/77952530-1c2fa200-72cc-11ea-84be-a9784aa2cf14.png)
Rail-Fence Dekriptimi
![RailFenceE](https://user-images.githubusercontent.com/58752918/77952532-1cc83880-72cc-11ea-9b69-aa311e2225d0.png)

----------------------------------------------------------------------------------------------------------------------------------------
Faza e pare ne C#

1. Cezar: Enkriptimi dhe dekriptimi
![Screenshot_4](https://user-images.githubusercontent.com/58752918/81016348-86ee7300-8e60-11ea-8b20-90a6269fc48c.png)

2.Vigenere: Enkriptimi dhe dekriptimi
![Screenshot_5](https://user-images.githubusercontent.com/58752918/81016784-62df6180-8e61-11ea-87e2-e618292850cb.png)

3.Rail-Fence: Enkriptimi dhe dekriptimi
![Screenshot_6](https://user-images.githubusercontent.com/58752918/81016965-bb166380-8e61-11ea-8030-f7814c34497e.png)

----------------------------------------------------------------------------------------------------------------------------------------

#FAZA E DYTE

  Ne fazen e dyte kemi pasur per detyre krijimin e 6 komandave. Komandat kane lidhje me njesite te cilat i kemi zhvilluar gjate kesaj kohe ne ligjerata, kryesisht me RSA dhe DES algoritmin. Komandat jane si ne vijim:

----------------------------------------------------------------------------------------------------------------------------------------
  
  ~ Create-user ~ e cila ka per qellim krijimin e nje xml fajllave ne te cilet do te ruhen qelsi publik dhe ai privat i RSA-se. Keta fajlla do te ruhen ne direktoriumin qe ne e kemi caktuar. Celesi publik ruhet ne fajllin "user.pub.xml" ndersa ai privat ne fajllin "user.xml", varesisht nga emri i userit. Ne e kemi caktuar folderin "keys" per ruajtjen e celsave, i cili ndodhet ne folderin e projektit.
  
  ![Screenshot_7](https://user-images.githubusercontent.com/58752918/81018079-134e6500-8e64-11ea-813e-43e5f5071fe6.png)
  ![Screenshot_8](https://user-images.githubusercontent.com/58752918/81018093-19444600-8e64-11ea-984d-db45aed847b9.png)

  Emri duhet te permbaje vetem shkronja, numra ose "_".
  ![Screenshot_9](https://user-images.githubusercontent.com/58752918/81018225-688a7680-8e64-11ea-8b38-1838ce0998e2.png)

----------------------------------------------------------------------------------------------------------------------------------------

  ~ Delete-user ~ e cila fshin fajllin me userin e caktuar ne rast se ai fajll ekziston.
  ![Screenshot_12](https://user-images.githubusercontent.com/58752918/81018539-02522380-8e65-11ea-8694-42271f1aea17.png)
  ![Screenshot_11](https://user-images.githubusercontent.com/58752918/81018567-1433c680-8e65-11ea-971b-87c0157f7304.png)
----------------------------------------------------------------------------------------------------------------------------------------
  
  
  
  ~ Export-key ~ kjo komande eksporton celesin publik ose privat varesisht nga argumenti i 2te nga nje fajll i caktuar. Ne rast se nuk caktohet shtegu ku do te eksportohet, atehere shfaqet permbajtja e celesit, ne te kunderten celesi eksportohet ne fajllin e caktuar.
  
  Ekzekutimi:
  
  ![Screenshot_13](https://user-images.githubusercontent.com/58752918/81019184-65908580-8e66-11ea-9ef7-2fc630fe1574.png)
  
  Nese caktohet shtegu:
  ![Screenshot_14](https://user-images.githubusercontent.com/58752918/81019528-2151b500-8e67-11ea-864d-85d600037b13.png)
  ![Screenshot_15](https://user-images.githubusercontent.com/58752918/81019535-257dd280-8e67-11ea-8537-999d9d497c2f.png)
     
   Permbajtja e fajllave:
  ![Screenshot_16](https://user-images.githubusercontent.com/58752918/81019544-29115980-8e67-11ea-8277-dd5895eae2c9.png)
  ![Screenshot_17](https://user-images.githubusercontent.com/58752918/81019546-2c0c4a00-8e67-11ea-9e72-8923a067cbbe.png)
----------------------------------------------------------------------------------------------------------------------------------------
  
  
  
  ~Import-key ~ kjo komande importon celesin publik ose privat, varesisht nga permbajtja e fajllit nga importohet. Fajllat qe do te sherbejne per importim jane some_key.xml dhe some_key1.xml. Ne rast se permbajtja e fajllit eshte celesi privat ai automatikisht gjeneron celesin publik dhe e ruan ate.
  
  Fajllat per importim:
  
  ![Screenshot_23](https://user-images.githubusercontent.com/58752918/81020489-3c252900-8e69-11ea-98d9-b6d71cb1b3de.png)

  Ekzekutimi i komandes:
  
  ![Screenshot_18](https://user-images.githubusercontent.com/58752918/81027594-b0b69280-8e7e-11ea-9d7b-9ceb6afd0257.png)
  ![Screenshot_19](https://user-images.githubusercontent.com/58752918/81020597-7262a880-8e69-11ea-82b1-8e70a582c9ef.png)
  
  Permbajtja e fajllave:
  
  ![Screenshot_20](https://user-images.githubusercontent.com/58752918/81021691-046bb080-8e6c-11ea-8fa1-e939bebc161d.png)
  ![Screenshot_25](https://user-images.githubusercontent.com/58752918/81021703-0d5c8200-8e6c-11ea-8c5b-4fcf9c1c0a26.png)
  ![Screenshot_24](https://user-images.githubusercontent.com/58752918/81021713-11889f80-8e6c-11ea-8f56-978c78522f17.png)
   
   Ne rastin kur shtegu fillon me http:  
   
  ![Screenshot_26](https://user-images.githubusercontent.com/58752918/81022180-41847280-8e6d-11ea-9fa3-cb9ae2b160d5.png)
  ![Screenshot_27](https://user-images.githubusercontent.com/58752918/81022068-f9fde680-8e6c-11ea-809f-6e6f68f4aba3.png)
  
----------------------------------------------------------------------------------------------------------------------------------------  
  
  ~ Write-message ~ kjo komande mundeson enkriptimin e mesazhit me ane te nje skeme te dhene, ne rast se nuk jipet shtegu ateher shfaqet mesazhi i enkriptuar, perndryshe mesazhi i enkriptuar ruhet ne nje fajll te caktuar.
  
  ![Screenshot_32](https://user-images.githubusercontent.com/58752918/81022884-1733b480-8e6f-11ea-96ee-6f1e929a9d39.png)
  ![Screenshot_30](https://user-images.githubusercontent.com/58752918/81022778-cf149200-8e6e-11ea-8fb7-fb884ad0f452.png)
  ![Screenshot_31](https://user-images.githubusercontent.com/58752918/81022788-d2a81900-8e6e-11ea-8491-0fe82dd310c8.png)
----------------------------------------------------------------------------------------------------------------------------------------

 ~ Read-message ~ kjo komande mundeson dekriptimin e mesazhit, dhe shfaqe marresin e mesazhit.
 
  ![Screenshot_33](https://user-images.githubusercontent.com/58752918/81026808-a21aac00-8e7b-11ea-9827-c0673ac6ce4b.png)
  
  Ndersa per dekriptim te mesazhit i cili ndodhet ne nje fajll kemi hasur ne keto errore:
  ![Screenshot_34](https://user-images.githubusercontent.com/58752918/81026914-148b8c00-8e7c-11ea-9e2d-e9cafafd361d.png)
----------------------------------------------------------------------------------------------------------------------------------------  
  Per realizimin e kodit i jemi referuar kodit te ushtrimeve si dhe disa burimeve online.
  Referencat:
  https://www.c-sharpcorner.com/UploadFile/75a48f/rsa-algorithm-with-C-Sharp2/
  https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsacryptoserviceprovider?view=netcore-3.1
  https://docs.microsoft.com/en-us/dotnet/framework/network-programming/how-to-request-data-using-the-webrequest-class
  https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.des.create?view=netcore-3.1
  
----------------------------------------------------------------------------------------------------------------------------------------


#FAZA E TRETE

Faza e trete parasheh vazhdimin e fazes se dyte, zgjerimin e disa komandave dhe shtimin e dy komandave te reja. Komandat te cilat eshte dashur te krijohen jane: create-user, delete-user, login, status, wrtie-message dhe read-message.
Kjo faze perfshin perdorimin e nenshkrimeve digjitale, te cilat i kemi punuar ne ligjerata dhe ushtrime. Komandat dhe funksionet e tyre jane te sqaruara ne vijim.

~ Create-user
Kjo komande ka per detyre krijimin e userit, ruajtjen e te dhenave ne databaze(ne kemi zgjedhur ti ruajm te dhenat ne databaze,SSMS), si dhe krijimin e RSA celesave. EKzekutimi i komandes:

![Screenshot_2](https://user-images.githubusercontent.com/58752918/83969198-df38ea80-a8ce-11ea-906e-6ca9cda6ad30.png)

Te dhenat ne databaze:

![Screenshot_4](https://user-images.githubusercontent.com/58752918/83969256-422a8180-a8cf-11ea-8c4d-f4761e6c7f8e.png)

XML fajllat:

![Screenshot_5](https://user-images.githubusercontent.com/58752918/83969320-a51c1880-a8cf-11ea-9527-3c823f29a38a.png)

----------------------------------------------------------------------------------------------------------------------------------------

~ Delete-user 

Kjo komande ka per detyre fshirjen e te dhenave te userit, pra te dhenat ne databaze dhe fajllat e krijuar. Ekzekutimi i komandes:

![Screenshot_6](https://user-images.githubusercontent.com/58752918/83969386-09d77300-a8d0-11ea-811d-2a810b282f56.png)

Fshirja e te dhenave nga databaza:

![Screenshot_7](https://user-images.githubusercontent.com/58752918/83969388-0cd26380-a8d0-11ea-8414-4fde6fc87c51.png)

Fshirja e XML fajllave: 

![Screenshot_8](https://user-images.githubusercontent.com/58752918/83969393-0f34bd80-a8d0-11ea-842b-6678eecb48e9.png)

----------------------------------------------------------------------------------------------------------------------------------------

~ Login

Komanda login sherben per "kycje" te userit. Ne raste se jane te dhenat e sakta, pra perputhen me te dhenat ne databaze, atehere logini eshte kryer me sukses dhe leshohet me token. Tokeni eshte gjeneruar sipas nje skeme qe e kemi zgjedhur vete pasi qe nuk ka funksionuar sipas JWT! Tokeni nesnshkruhet me celsin privat te userit. Ne rastin kur te dhenat nuk perputhen ateher shfaqet mesazhi: "Shfrytezuesi ose fjalekalimi i gabuar!". Ekzekutimi i komandes: 

![Screenshot_9](https://user-images.githubusercontent.com/58752918/83970180-8e2bf500-a8d4-11ea-8c40-127a96b95fad.png)

----------------------------------------------------------------------------------------------------------------------------------------

~ Status

Komanda status jep te dhenat rreth tokenit nese eshte valid ose jo, si dhe paraqet daten e skadimit te tokenit. Verifikimi behet me ane te celsit publik te userit. Ekzekutimi i komandes:

![Screenshot_10](https://user-images.githubusercontent.com/58752918/83970698-570b1300-a8d7-11ea-8508-15826fb3530c.png)

----------------------------------------------------------------------------------------------------------------------------------------

~ Write-message

Komanda write-message, e zgjeruar, e cila perfshin edhe derguesin si dhe nenshkruan tekstin nese tokeni i userit eshte valid.
Ekzekutimi i komandes: 

![Screenshot_11](https://user-images.githubusercontent.com/59438009/83974976-4e273b00-a8f1-11ea-8152-e88d9b71578f.png)


Ne rast se ndryshojme diqka emrin e derguesit verejme se shfaqet mesazhi:

![Screenshot_13](https://user-images.githubusercontent.com/59438009/83976900-4ec5ce80-a8fd-11ea-913e-be8cbe597069.png)

![Screenshot_14](https://user-images.githubusercontent.com/59438009/83976922-7452d800-a8fd-11ea-9bb5-23dc358e913a.png)


----------------------------------------------------------------------------------------------------------------------------------------

~ Read-message

Komanda read-message ben dekriptimin e mesazhit te shkruar dhe tregon nese nenshkrimi eshte valid apo jo. Ekzekutimi i komandes:

![read](https://user-images.githubusercontent.com/59438009/83977255-761d9b00-a8ff-11ea-89ce-a997b8c30867.jpg)












  

