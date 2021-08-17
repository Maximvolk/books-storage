create table "Author" (
    "Id" serial primary key,
    "Name" varchar(100) not null
);

create table "Book" (
    "Id" serial primary key,
    "Title" varchar(100) not null
);

create table "AuthorBook" (
    "AuthorsId" int not null,
    "BooksId" int not null,
    foreign key ("AuthorsId") references "Author"("Id") on delete cascade,
    foreign key ("BooksId") references "Book"("Id") on delete cascade
);