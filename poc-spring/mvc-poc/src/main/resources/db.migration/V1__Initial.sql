-- Table: public.personen

-- DROP TABLE public.personen;

CREATE TABLE public.personen
(
    id bigint NOT NULL,
    voornaam character varying(255) COLLATE pg_catalog."default" NOT NULL,
    achternaam character varying(255) COLLATE pg_catalog."default" NOT NULL,
    leeftijd smallint,
    CONSTRAINT personen_pkey PRIMARY KEY (id)
)
    WITH (
        OIDS = FALSE
        )
    TABLESPACE pg_default;

ALTER TABLE public.personen
    OWNER to postgres;