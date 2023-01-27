use BookStore
create table Admin(
AdminID int primary key identity,
AdminName varchar(255) not null,
AdminEmailID varchar(255) unique not null,
AdminMobile bigint not null,
AdminPassword varchar(255) not null
)
insert into Admin values('PavanDesale','desalepavan123@gmail.com',1234765895,'pavan@123')

select * from Admin


---------------- Store procedure for Admin login --------------

alter procedure SPAdminLogin
(
@AdminEmailID varchar(255),
@AdminPassword varchar(255)
)
As
Begin 
select * from Admin where @AdminEmailID=@AdminEmailID and @AdminPassword=@AdminPassword;
end 
