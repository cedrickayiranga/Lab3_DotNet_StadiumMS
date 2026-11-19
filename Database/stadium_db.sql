CREATE DATABASE IF NOT EXISTS stadium_db
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_general_ci;

USE stadium_db;

CREATE TABLE IF NOT EXISTS users (
    id            INT AUTO_INCREMENT PRIMARY KEY,
    full_name     VARCHAR(200) NOT NULL,
    email         VARCHAR(150) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    is_admin      TINYINT(1)   NOT NULL DEFAULT 0,
    created_at    DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS events (
    id             INT AUTO_INCREMENT PRIMARY KEY,
    title          VARCHAR(100) NOT NULL,
    description    TEXT,
    start_datetime DATETIME     NOT NULL,
    end_datetime   DATETIME     NOT NULL,
    max_tickets    INT          NOT NULL,
    created_at     DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS event_seats (
    id          INT AUTO_INCREMENT PRIMARY KEY,
    event_id    INT           NOT NULL,
    seat_number VARCHAR(50)   NOT NULL,
    price       DECIMAL(10,2) NOT NULL,
    is_booked   TINYINT(1)    NOT NULL DEFAULT 0,
    booked_at   DATETIME      NULL,
    UNIQUE KEY uq_event_seat (event_id, seat_number),
    CONSTRAINT fk_seat_event FOREIGN KEY (event_id) REFERENCES events(id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS tickets (
    id             INT AUTO_INCREMENT PRIMARY KEY,
    user_id        INT           NOT NULL,
    event_id       INT           NOT NULL,
    seat_id        INT           NOT NULL UNIQUE,
    price          DECIMAL(10,2) NOT NULL,
    payment_method VARCHAR(30)   NOT NULL,
    status         VARCHAR(20)   NOT NULL DEFAULT 'paid',
    created_at     DATETIME      NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_ticket_user  FOREIGN KEY (user_id)  REFERENCES users(id),
    CONSTRAINT fk_ticket_event FOREIGN KEY (event_id) REFERENCES events(id),
    CONSTRAINT fk_ticket_seat  FOREIGN KEY (seat_id)  REFERENCES event_seats(id)
);

