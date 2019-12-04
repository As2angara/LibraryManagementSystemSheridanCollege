/*
    The tables for .NET Library Management Systems
    By: Adrian Angara
*/

drop table Loan;
drop table Book_Copy;
drop table Book;
drop table Overdues;
drop table LibUsers;

Create table Book 
(
    [Book_Id] int identity(1,1) not null,
	[Book_title] varchar(256),
    [Genre] varchar(256),
    [Author] varchar(256),
    [Publisher] varchar(256),
	PRIMARY KEY CLUSTERED (Book_Id ASC)
);

create table Book_Copy 
(
    BookCopy_Id int identity(1,1) not null,
    Book_Id int not null,
	Availability varchar(24),
	PRIMARY KEY CLUSTERED (BookCopy_Id ASC),
    constraint fk_book
        foreign key (Book_Id) references Book(Book_id)
);

create table Loan 
(
    Loan_Id int identity(1,1) not null,
    User_Id int not null,
    issue_date date,
    due_date date,
    return_date date,
    BookCopy_Id int not null,
	PRIMARY KEY CLUSTERED (Loan_Id ASC),
    constraint fk_book_copy
        foreign key (BookCopy_Id) references Book_Copy(BookCopy_Id) 
);

create table Overdues 
(
    Overdue_Id int identity(1,1) not null,
    loan_id int not null,
    amount_due decimal (10, 2) not null,
	amount_paid decimal (10, 2),
    date_paid date
	PRIMARY KEY CLUSTERED (Overdue_Id ASC)
);

create table LibUsers 
(
    User_Id int identity(1,1) not null,
	username   VARCHAR (24) NOT NULL,
    password   VARCHAR (50) NOT NULL,
	home_address varchar(256),
	phone_num varchar(24),
	email varchar(256),
	Role_Name varchar(24),
	filepath varchar(256), 
	isRequestDelete varchar(5),
	PRIMARY KEY CLUSTERED (User_Id ASC)
);

/*Insert statements: LibUsers*/
insert into Book (Book_title, Genre, Author, Publisher) 
	values ('Fifth Business', 'Fiction',  'Robertson Davies', 'Macmillan of Canada');
insert into Book (Book_title,Genre, Author, Publisher) 
	values ('12 Rules for life' ,'Self-help',  'Jordan Peterson', 'Allen Lane');
insert into Book (Book_title, Genre, Author, Publisher) 
	values ('Neuromancer', 'Science Fiction',  'William Gibson', 'Ace Books');
insert into Book (Book_title,Genre, Author, Publisher) 
	values ('Pride and Prejudice' ,'Romance',  'Jane Austen', 'Thomas Egerton');
insert into Book (Book_title, Genre, Author, Publisher) 
	values ('Environment Today', 'Educational',  'Frank Favers', 'Geography Publication');
insert into Book (Book_title, Genre, Author, Publisher) 
	values ('Decaf', 'Autobiography',  'Larence Narcist', 'Influencers of Canada');
insert into Book (Book_title, Genre, Author, Publisher) 
	values ('Hat-trick', 'Fiction',  'Robert Munch', 'Shots Shots Shots');
insert into Book (Book_title, Genre, Author, Publisher) 
	values ('Dewenry', 'Science Fiction',  'V.V. Vanvleet', 'Raptors');
insert into Book (Book_title, Genre, Author, Publisher) 
	values ('NO LOVE', 'Self-help',  'Lonzo Ball', 'NOLA from LA');
insert into Book (Book_title, Genre, Author, Publisher) 
	values ('How Tigers Work', 'Educational',  'a real tiger', 'Meow Inc');

insert into Book_Copy (Book_Id, Availability) values (1, 'Available');
insert into Book_Copy (Book_Id, Availability) values (2, 'Available');
insert into Book_Copy (Book_Id, Availability) values (3, 'Available');
insert into Book_Copy (Book_Id, Availability) values (4, 'Available');
insert into Book_Copy (Book_Id, Availability) values (4, 'Available');
insert into Book_Copy (Book_Id, Availability) values (4, 'Available');
insert into Book_Copy (Book_Id, Availability) values (5, 'Available');
insert into Book_Copy (Book_Id, Availability) values (6, 'Available');
insert into Book_Copy (Book_Id, Availability) values (6, 'Available');
insert into Book_Copy (Book_Id, Availability) values (7, 'Available');
insert into Book_Copy (Book_Id, Availability) values (7, 'Available');
insert into Book_Copy (Book_Id, Availability) values (10, 'Available');
insert into Book_Copy (Book_Id, Availability) values (9, 'Available');
insert into Book_Copy (Book_Id, Availability) values (9, 'Available');
insert into Book_Copy (Book_Id, Availability) values (8, 'Available');
insert into Book_Copy (Book_Id, Availability) values (8, 'Available');

insert into LibUsers (username, password, Role_Name, home_address, phone_num, email, filepath) 
	values ('Member', '76937665F81C3F3C019B9B3C27247D2D', 'Member', '130 Northlake Blvd.',
			'647-779-8039', 'memberemail@gmail.com', 'facebook_default.jpg');

insert into LibUsers (username, password, Role_Name,  home_address, phone_num, email, filepath) 
	values ('Librarian', '76937665F81C3F3C019B9B3C27247D2D', 'Librarian',  '345 Cawthra Rd.',
			'647-538-0184', 'librarianemail@gmail.com', 'facebook_default.jpg');

insert into LibUsers (username, password, Role_Name) 
	values ('Admin', '76937665F81C3F3C019B9B3C27247D2D', 'Admin');


--Testing Overdues
insert into Loan (User_Id, issue_date, due_date, BookCopy_Id)
	values (1, '2019-11-18', '2019-11-29', 1);

insert into Overdues (Loan_Id, amount_due) values (1, 0.5);

update Book_Copy set Availability = 'Unavailable' where BookCopy_Id = 1;
	
