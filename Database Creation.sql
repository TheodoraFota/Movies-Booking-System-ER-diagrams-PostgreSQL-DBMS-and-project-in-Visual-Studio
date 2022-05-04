CREATE TABLE "seats" (
  "seat_id" serial,
  "tid" serial,
  "seat_name" varchar,
  "No_of_seats" int NOT NULL,
  PRIMARY KEY ("seat_id", "tid")
);

CREATE TABLE "theatre" (
  "tid" serial PRIMARY KEY,
  "tname" varchar NOT NULL,
  "address" varchar,
  "zip" int
);

CREATE TABLE "customer" (
  "cid" serial PRIMARY KEY,
  "cname" varchar NOT NULL,
  "password" varchar NOT NULL,
  "email_id" varchar NOT NULL,
  "date_of_birth" date NOT NULL,
  "phone_no" int NOT NULL
);

CREATE TABLE "tickets" (
  "tickets_no" serial PRIMARY KEY,
  "admin_id" int NOT NULL,
  "show_date" date NOT NULL,
  "seat_no" int,
  "price" int check(price>0),
  "tid" int ,
  "hall_no" int,
  "show_id" int,
  "cid" int,
  "booking_date" date NOT NULL
);

CREATE TABLE "admin" (
  "admin_id" serial PRIMARY KEY,
  "password" varchar NOT NULL
);

CREATE TABLE "discount" (
  "offer_id" serial,
  "tickets_no" serial,
  "d_name" varchar,
  "price" int check(price>0),
  PRIMARY KEY ("offer_id", "tickets_no")
);

CREATE TABLE "show" (
  "show_id" serial PRIMARY KEY,
  "m_id" int,
  "end_time" timestamp NOT NULL,
  "start_time" timestamp NOT NULL,
  "language" varchar
);

CREATE TABLE "movie" (
  "m_id" serial PRIMARY KEY,
  "show_id" int,
  "m_name" varchar NOT NULL,
  "release_date" date
);

CREATE TABLE "actors" (
  "m_id" serial,
  "actor" varchar,
  PRIMARY KEY ("m_id", "actor")
);

CREATE TABLE "director" (
  "m_id" serial,
  "director" varchar,
  PRIMARY KEY ("m_id", "director")
);

CREATE TABLE "workfor" (
  "admin_id" serial,
  "tid" serial,
  PRIMARY KEY ("admin_id", "tid")
);


ALTER TABLE "seats" ADD FOREIGN KEY ("tid") REFERENCES "theatre" ("tid");

ALTER TABLE "director" ADD FOREIGN KEY ("m_id") REFERENCES "movie" ("m_id");

ALTER TABLE "actors" ADD FOREIGN KEY ("m_id") REFERENCES "movie" ("m_id");

ALTER TABLE "tickets" ADD FOREIGN KEY ("cid") REFERENCES "customer" ("cid");

ALTER TABLE "movie" ADD FOREIGN KEY ("show_id") REFERENCES "show" ("show_id");

ALTER TABLE "tickets" ADD FOREIGN KEY ("show_id") REFERENCES "show" ("show_id");

ALTER TABLE "discount" ADD FOREIGN KEY ("tickets_no") REFERENCES "tickets" ("tickets_no");

ALTER TABLE "tickets" ADD FOREIGN KEY ("admin_id") REFERENCES "admin" ("admin_id");

ALTER TABLE "tickets" ADD FOREIGN KEY ("tid") REFERENCES "theatre" ("tid");

ALTER TABLE workfor ADD FOREIGN KEY ("tid") REFERENCES "theatre" ("tid");

ALTER TABLE workfor ADD FOREIGN KEY ("admin_id") REFERENCES "admin" ("admin_id");
