-- Habilitar el uso de claves foráneas
PRAGMA foreign_keys = ON;

-- Crear tablas
CREATE TABLE IF NOT EXISTS Miembro (
    id_Miembro INTEGER PRIMARY KEY,
    Nombre TEXT NOT NULL,
    Cedula TEXT NOT NULL,
    Telefono TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Entrenador (
    id_Entrenador INTEGER PRIMARY KEY,
    fname TEXT NOT NULL,
    lname TEXT NOT NULL,
    email TEXT NULL UNIQUE
);

CREATE Table IF NOT EXISTS Miembro_Entrenador (
    Miembro_id INTEGER NOT NULL,
    Entrenador_id INTEGER NOT NULL,
    FOREIGN KEY (Miembro_id) REFERENCES Miembro (id_Miembro),
    FOREIGN KEY (Entrenador_id) REFERENCES Entrenador (id_Entrenador),
    -- Clave primaria compuesta -> asegura que un autor no se relacione dos veces en el mismo libro.
    PRIMARY KEY (Miembro_id, author_id)
);

-- Insertar libros
INSERT INTO
    Miembro (Nombre, Cedula, Telefono)
VALUES (
        'juan LUIS',
        '40283892239',
        '829-232-2344'
    ),
    (
        'Ana Frank',
        '40283895679',
        '829-298-3333'
    ),
    (
        'Sofía Elene',
        '40209872239',
        '829-229-4983'
    ),
    (
        'Nigua de Nagua',
        '40239872239',
        '829-393-2882'
    );

-- Insertar autores
INSERT INTO
    Entrenador (fname, lname)
VALUES ('Aldous', 'Huxley'),
    ('Ana', 'Frank'),
    ('Jostein', 'Jostein Gaarder');

INSERT INTO
    Miembro_Entrenador (Miembro_id, Entrenador_id)
VALUES (1, 1),
    (2, 2),
    (3, 3),
    (4, 1);

-- Consulta con tablas relacionadas
SELECT fname, lname, Nombre
FROM
    Miembro_Entrenador
    INNER JOIN Entrenador ON Miembro_Entrenador.Entrenador_id = Entrenador.id_Entrenador
    INNER JOIN Miembro ON Miembro_Entrenador.Miembro_id = Miembro.id_Miembro;