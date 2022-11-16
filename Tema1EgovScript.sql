create table Teatru(
	TeatruId uniqueidentifier not null primary key,
	Nume nvarchar(100) not null,
)

insert into [Teatru] values (NEWID(), 'Teatrul Bulandra');
insert into [Teatru] values (NEWID(), 'Teatrul de Comedie');
insert into [Teatru] values (NEWID(), 'Teatrul Ion Creangă');
insert into [Teatru] values (NEWID(), 'Teatrul Metropolis');
insert into [Teatru] values (NEWID(), 'Teatrul Mic');
insert into [Teatru] values (NEWID(), 'Teatrul Național „Ion Luca Caragiale”');
insert into [Teatru] values (NEWID(), 'Teatrul Național de Operetă „Ion Dacian” București');
insert into [Teatru] values (NEWID(), 'Teatrul Nottara');
insert into [Teatru] values (NEWID(), 'Teatrul Odeon');
insert into [Teatru] values (NEWID(), 'Teatrul Excelsior');
insert into [Teatru] values (NEWID(), 'Teatrul Evreiesc de Stat');
insert into [Teatru] values (NEWID(), 'Teatrul Stela Popescu');
insert into [Teatru] values (NEWID(), 'Teatrul Dramaturgilor');
insert into [Teatru] values (NEWID(), 'Teatrul Masca');
insert into [Teatru] values (NEWID(), 'Teatrul Țăndărică');

create table Piesa(
	PiesaId uniqueidentifier not null primary key,
	TeatruId uniqueidentifier not null,
	Nume nvarchar(200) not null,

	constraint FK_Piesa_Teatru foreign key (TeatruId)
	references [Teatru](TeatruId),
)

insert into [Piesa] values (NEWID(), '74e8612d-4957-42c9-a86a-109d67421a11', 'Micul Infern')
insert into [Piesa] values (NEWID(), '74e8612d-4957-42c9-a86a-109d67421a11', 'Jubileul unei banci private')
insert into [Piesa] values (NEWID(), '74e8612d-4957-42c9-a86a-109d67421a11', 'Gaitele')
insert into [Piesa] values (NEWID(), 'f67584fb-43ba-4f1d-b4b1-bf2c26841db2', 'Dineu cu prosti')
insert into [Piesa] values (NEWID(), 'f67584fb-43ba-4f1d-b4b1-bf2c26841db2', 'Tectonica sentimentelor')
insert into [Piesa] values (NEWID(), 'f67584fb-43ba-4f1d-b4b1-bf2c26841db2', 'Anonim Venetian')
insert into [Piesa] values (NEWID(), '5c63bac9-846f-4c94-bf88-c1f3e6b907b9', 'Degetica')
insert into [Piesa] values (NEWID(), '5c63bac9-846f-4c94-bf88-c1f3e6b907b9', 'Jack si vrejul de fasole')
insert into [Piesa] values (NEWID(), '5c63bac9-846f-4c94-bf88-c1f3e6b907b9', 'Fat-frumos din lacrima')
insert into [Piesa] values (NEWID(), '4f913814-61df-41d0-83b6-3bb16027aca3', 'Prima intalnire')
insert into [Piesa] values (NEWID(), '309a6c85-a4e9-451e-92be-50b2d08c044b', 'Praf de stele')
insert into [Piesa] values (NEWID(), '4f913814-61df-41d0-83b6-3bb16027aca31', 'Iona')
insert into [Piesa] values (NEWID(), '309a6c85-a4e9-451e-92be-50b2d08c044b', 'O scrisoare pierduta')
insert into [Piesa] values (NEWID(), '309a6c85-a4e9-451e-92be-50b2d08c044b', 'Domnul Goe')
insert into [Piesa] values (NEWID(), '0df875bf-08ac-4c7f-8cb2-b122b42fc505', 'Pisica pe acoperișul fierbinte')
insert into [Piesa] values (NEWID(), '0df875bf-08ac-4c7f-8cb2-b122b42fc505', 'O stafidă in soare')
insert into [Piesa] values (NEWID(), 'd5359f72-4f21-45b4-9a50-52623fd45669', 'Un tramvai numit dorință')
insert into [Piesa] values (NEWID(), 'b9e28f33-de07-4af1-8f3b-8602bcc899b6', 'Romeo și Julieta')
insert into [Piesa] values (NEWID(), 'b9e28f33-de07-4af1-8f3b-8602bcc899b6', 'Hamlet')

create table Orar(
	OrarId uniqueidentifier not null primary key,
	PiesaId uniqueidentifier not null,
	DataOra  datetime, 
	Pret float,

	constraint FK_Orar_Piesa foreign key (PiesaId)
	references [Piesa](PiesaId),
)

insert into [Orar] values (NEWID(), '15A1EFAC-3C1E-4F7C-BF55-07AF991DE4F4', '2022-10-27 20:00', 120)
insert into [Orar] values (NEWID(), '5125F20B-663C-4FFA-91EF-0E678E657690', '2022-10-27 21:00', 120)
insert into [Orar] values (NEWID(), '3F8FAF39-2690-4F82-869D-342877EEB403', '2022-10-28 20:30', 120)
insert into [Orar] values (NEWID(), 'CCAED9E2-BEF4-488E-A1DE-44AE386A6C42', '2022-10-28 18:00', 120)
insert into [Orar] values (NEWID(), '283380E3-8271-49A1-A393-597E9D11AAF0', '2022-10-29 21:00', 120)
insert into [Orar] values (NEWID(), '1E35BA00-21C3-4C18-B020-60760B8BE7DB', '2022-10-29 20:00',150)
insert into [Orar] values (NEWID(), '23DC4CB4-28DD-41C7-A459-6330F1F71FB6', '2022-10-30 19:00',150)
insert into [Orar] values (NEWID(), '1E7559B3-CAFB-46DD-B8E7-763B5DF8C90A', '2022-10-30 18:00',150)
insert into [Orar] values (NEWID(), '43E95471-9FDE-4794-AB54-7843536F1F56', '2022-10-30 18:00',150)
insert into [Orar] values (NEWID(), 'A5E92037-9AB7-4C07-9435-7FC4778D5E0E', '2022-10-27 20:00',150)
insert into [Orar] values (NEWID(), '2243FA50-F505-416C-9893-7FF832F455D9', '2022-11-01 17:00',150)
insert into [Orar] values (NEWID(), '9D370284-EC0F-4DFE-8848-90CB4078EF61', '2022-11-02 20:00',150)
insert into [Orar] values (NEWID(), '1DD63CA7-8A86-4A99-9D58-A49831CBF05D', '2022-10-01 20:00',150)
insert into [Orar] values (NEWID(), 'D0FC86E7-0309-481E-999D-B8E4E1DBDE39', '2022-10-03 20:00',150)
insert into [Orar] values (NEWID(), '63340EAA-E8A8-468F-B997-C4F43C4EDCE2', '2022-10-05 20:00',150)
insert into [Orar] values (NEWID(), '7E73A8B2-34EB-48D3-A478-C70408251327', '2022-10-05 20:00', 120)
insert into [Orar] values (NEWID(), '48DB363B-E5C5-47CD-AAE1-E90AF05424EA', '2022-10-10 20:00', 120)
insert into [Orar] values (NEWID(), '85BB64C3-6B61-4425-B203-F36B8CED9E40', '2022-10-10 20:00', 120)
insert into [Orar] values (NEWID(), '56883CC4-BFC7-43C4-B610-F434AC2BDE08', '2022-10-17 20:00', 120)
insert into [Orar] values (NEWID(), '15A1EFAC-3C1E-4F7C-BF55-07AF991DE4F4', '2022-11-17 18:30', 150)
insert into [Orar] values (NEWID(), '5125F20B-663C-4FFA-91EF-0E678E657690', '2022-11-17 21:00', 100)
insert into [Orar] values (NEWID(), '3F8FAF39-2690-4F82-869D-342877EEB403', '2022-11-18 20:30', 150)
insert into [Orar] values (NEWID(), 'CCAED9E2-BEF4-488E-A1DE-44AE386A6C42', '2022-11-18 19:30', 200)
insert into [Orar] values (NEWID(), '283380E3-8271-49A1-A393-597E9D11AAF0', '2022-11-19 21:00', 100)
insert into [Orar] values (NEWID(), '1E35BA00-21C3-4C18-B020-60760B8BE7DB', '2022-11-19 18:30', 80)
insert into [Orar] values (NEWID(), '23DC4CB4-28DD-41C7-A459-6330F1F71FB6', '2022-11-30 19:00', 100)
insert into [Orar] values (NEWID(), '1E7559B3-CAFB-46DD-B8E7-763B5DF8C90A', '2022-11-30 19:30', 60)
insert into [Orar] values (NEWID(), '43E95471-9FDE-4794-AB54-7843536F1F56', '2022-11-30 19:30', 170)
insert into [Orar] values (NEWID(), 'A5E92037-9AB7-4C07-9435-7FC4778D5E0E', '2022-12-27 18:30', 140)
insert into [Orar] values (NEWID(), '2243FA50-F505-416C-9893-7FF832F455D9', '2022-12-01 17:00', 100)
insert into [Orar] values (NEWID(), '9D370284-EC0F-4DFE-8848-90CB4078EF61', '2022-12-02 18:30', 130)
insert into [Orar] values (NEWID(), '1DD63CA7-8A86-4A99-9D58-A49831CBF05D', '2022-12-01 18:30', 100)
insert into [Orar] values (NEWID(), 'D0FC86E7-0309-481E-999D-B8E4E1DBDE39', '2022-12-03 18:30', 100)
insert into [Orar] values (NEWID(), '63340EAA-E8A8-468F-B997-C4F43C4EDCE2', '2022-12-05 18:30', 100)
insert into [Orar] values (NEWID(), '7E73A8B2-34EB-48D3-A478-C70408251327', '2022-11-05 18:30', 150)
insert into [Orar] values (NEWID(), '48DB363B-E5C5-47CD-AAE1-E90AF05424EA', '2022-11-10 18:30', 100)
insert into [Orar] values (NEWID(), '85BB64C3-6B61-4425-B203-F36B8CED9E40', '2022-11-10 18:30', 80)
insert into [Orar] values (NEWID(), '56883CC4-BFC7-43C4-B610-F434AC2BDE08', '2022-12-17 18:30', 100)

create table Rezervare (
	RezervareId uniqueidentifier not null primary key,
	OrarId uniqueidentifier not null,
	Nume nvarchar(100) not null,
	Prenume nvarchar(100) not null,
	Email nvarchar(100) not null,
	Student bit,
	Pensionar bit
)