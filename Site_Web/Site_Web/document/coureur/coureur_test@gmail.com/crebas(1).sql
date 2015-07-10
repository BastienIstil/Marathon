/*==============================================================*/
/* Nom de SGBD :  Microsoft SQL Server 2008                     */
/* Date de création :  06/05/2015 13:55:13                      */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_E_COUREUR_COU') and o.name = 'FK_T_E_COUR_EST_AFFIL_T_R_CLUB')
alter table T_E_COUREUR_COU
   drop constraint FK_T_E_COUR_EST_AFFIL_T_R_CLUB
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_E_COUREUR_COU') and o.name = 'FK_T_E_COUR_EST_DEFIN_T_R_CATE')
alter table T_E_COUREUR_COU
   drop constraint FK_T_E_COUR_EST_DEFIN_T_R_CATE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_J_DEFICOURSE_DEC') and o.name = 'FK_T_J_DEFI_CONTIENT_T_R_DEFI')
alter table T_J_DEFICOURSE_DEC
   drop constraint FK_T_J_DEFI_CONTIENT_T_R_DEFI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_J_DEFICOURSE_DEC') and o.name = 'FK_T_J_DEFI_CONTIENT2_T_R_COUR')
alter table T_J_DEFICOURSE_DEC
   drop constraint FK_T_J_DEFI_CONTIENT2_T_R_COUR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_J_GENERATION_GEN') and o.name = 'FK_T_J_GENE_GENERE_T_E_COUR')
alter table T_J_GENERATION_GEN
   drop constraint FK_T_J_GENE_GENERE_T_E_COUR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_J_GENERATION_GEN') and o.name = 'FK_T_J_GENE_GENERE2_T_E_CLAS')
alter table T_J_GENERATION_GEN
   drop constraint FK_T_J_GENE_GENERE2_T_E_CLAS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_J_GENERATION_GEN') and o.name = 'FK_T_J_GENE_GENERE3_T_R_COUR')
alter table T_J_GENERATION_GEN
   drop constraint FK_T_J_GENE_GENERE3_T_R_COUR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_J_PARTICIPATIONDEFI_PAD') and o.name = 'FK_T_J_PART_PARTICIPE_T_E_COUR')
alter table T_J_PARTICIPATIONDEFI_PAD
   drop constraint FK_T_J_PART_PARTICIPE_T_E_COUR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_J_PARTICIPATIONDEFI_PAD') and o.name = 'FK_T_J_PART_PARTICIPE_T_R_DEFI')
alter table T_J_PARTICIPATIONDEFI_PAD
   drop constraint FK_T_J_PART_PARTICIPE_T_R_DEFI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_J_PARTICIPATIONENGROUPE_PEG') and o.name = 'FK_T_J_PART_PARTICIPE_T_R_COUR')
alter table T_J_PARTICIPATIONENGROUPE_PEG
   drop constraint FK_T_J_PART_PARTICIPE_T_R_COUR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_J_PARTICIPATIONENGROUPE_PEG') and o.name = 'FK_T_J_PART_PARTICIPE_T_R_CLUB')
alter table T_J_PARTICIPATIONENGROUPE_PEG
   drop constraint FK_T_J_PART_PARTICIPE_T_R_CLUB
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_J_PARTICIPATIONENGROUPE_PEG') and o.name = 'FK_T_J_PART_PARTICIPE_T_E_PAIE')
alter table T_J_PARTICIPATIONENGROUPE_PEG
   drop constraint FK_T_J_PART_PARTICIPE_T_E_PAIE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_J_PARTICIPATION_PAR') and o.name = 'FK_PART_COU')
alter table T_J_PARTICIPATION_PAR
   drop constraint FK_PART_COU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_J_PARTICIPATION_PAR') and o.name = 'FK_PART_COR')
alter table T_J_PARTICIPATION_PAR
   drop constraint FK_PART_COR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_J_PARTICIPATION_PAR') and o.name = 'FK_PART_PAI')
alter table T_J_PARTICIPATION_PAR
   drop constraint FK_PART_PAI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_J_TEMPSCOUBORNE_TCB') and o.name = 'FK_T_J_TEMP_DISTRIBUE_T_E_COUR')
alter table T_J_TEMPSCOUBORNE_TCB
   drop constraint FK_T_J_TEMP_DISTRIBUE_T_E_COUR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_J_TEMPSCOUBORNE_TCB') and o.name = 'FK_T_J_TEMP_EST_COMPO_T_R_BORN')
alter table T_J_TEMPSCOUBORNE_TCB
   drop constraint FK_T_J_TEMP_EST_COMPO_T_R_BORN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_R_BORNE_BOR') and o.name = 'FK_T_R_BORN_EST_COMPO_T_R_COUR')
alter table T_R_BORNE_BOR
   drop constraint FK_T_R_BORN_EST_COMPO_T_R_COUR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('T_R_LOT_LOT') and o.name = 'FK_T_R_LOT__DISTRIBUE_T_E_COUR')
alter table T_R_LOT_LOT
   drop constraint FK_T_R_LOT__DISTRIBUE_T_E_COUR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_E_CLASSEMENT_CLA')
            and   type = 'U')
   drop table T_E_CLASSEMENT_CLA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_E_COUREUR_COU')
            and   name  = 'IDX_COU_COU_PRENOM'
            and   indid > 0
            and   indid < 255)
   drop index T_E_COUREUR_COU.IDX_COU_COU_PRENOM
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_E_COUREUR_COU')
            and   name  = 'IDX_COU_COU_NOM'
            and   indid > 0
            and   indid < 255)
   drop index T_E_COUREUR_COU.IDX_COU_COU_NOM
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_E_COUREUR_COU')
            and   name  = 'IDX_COU_CAT_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_E_COUREUR_COU.IDX_COU_CAT_ID
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_E_COUREUR_COU')
            and   name  = 'IDX_COU_CLU_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_E_COUREUR_COU.IDX_COU_CLU_ID
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_E_COUREUR_COU')
            and   type = 'U')
   drop table T_E_COUREUR_COU
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_E_INFORMATIONPUBLIQUE_INF')
            and   type = 'U')
   drop table T_E_INFORMATIONPUBLIQUE_INF
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_E_INSCRIT_INS')
            and   type = 'U')
   drop table T_E_INSCRIT_INS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_E_PAIEMENT_PAI')
            and   type = 'U')
   drop table T_E_PAIEMENT_PAI
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_J_DEFICOURSE_DEC')
            and   name  = 'IDX_DEC_COR_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_J_DEFICOURSE_DEC.IDX_DEC_COR_ID
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_J_DEFICOURSE_DEC')
            and   name  = 'IDX_DEC_DEF_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_J_DEFICOURSE_DEC.IDX_DEC_DEF_ID
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_J_DEFICOURSE_DEC')
            and   type = 'U')
   drop table T_J_DEFICOURSE_DEC
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_J_GENERATION_GEN')
            and   name  = 'IDX_GEN_COR_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_J_GENERATION_GEN.IDX_GEN_COR_ID
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_J_GENERATION_GEN')
            and   name  = 'IDX_GEN_CLA_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_J_GENERATION_GEN.IDX_GEN_CLA_ID
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_J_GENERATION_GEN')
            and   name  = 'IDX_GEN_COU_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_J_GENERATION_GEN.IDX_GEN_COU_ID
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_J_GENERATION_GEN')
            and   type = 'U')
   drop table T_J_GENERATION_GEN
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_J_PARTICIPATIONDEFI_PAD')
            and   name  = 'IDX_PAD_DEF_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_J_PARTICIPATIONDEFI_PAD.IDX_PAD_DEF_ID
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_J_PARTICIPATIONDEFI_PAD')
            and   name  = 'IDX_PAD_COU_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_J_PARTICIPATIONDEFI_PAD.IDX_PAD_COU_ID
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_J_PARTICIPATIONDEFI_PAD')
            and   type = 'U')
   drop table T_J_PARTICIPATIONDEFI_PAD
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_J_PARTICIPATIONENGROUPE_PEG')
            and   name  = 'IDX_PEG_PAI_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_J_PARTICIPATIONENGROUPE_PEG.IDX_PEG_PAI_ID
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_J_PARTICIPATIONENGROUPE_PEG')
            and   name  = 'IDX_PEG_CLU_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_J_PARTICIPATIONENGROUPE_PEG.IDX_PEG_CLU_ID
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_J_PARTICIPATIONENGROUPE_PEG')
            and   name  = 'IDX_PEG_COU_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_J_PARTICIPATIONENGROUPE_PEG.IDX_PEG_COU_ID
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_J_PARTICIPATIONENGROUPE_PEG')
            and   type = 'U')
   drop table T_J_PARTICIPATIONENGROUPE_PEG
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_J_PARTICIPATION_PAR')
            and   name  = 'IDX_PAR_PAR_DOSSARD'
            and   indid > 0
            and   indid < 255)
   drop index T_J_PARTICIPATION_PAR.IDX_PAR_PAR_DOSSARD
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_J_PARTICIPATION_PAR')
            and   name  = 'IDX_PAR_PAI_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_J_PARTICIPATION_PAR.IDX_PAR_PAI_ID
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_J_PARTICIPATION_PAR')
            and   name  = 'IDX_PAR_COR_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_J_PARTICIPATION_PAR.IDX_PAR_COR_ID
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_J_PARTICIPATION_PAR')
            and   name  = 'IDX_PAR_COU_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_J_PARTICIPATION_PAR.IDX_PAR_COU_ID
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_J_PARTICIPATION_PAR')
            and   type = 'U')
   drop table T_J_PARTICIPATION_PAR
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_J_TEMPSCOUBORNE_TCB')
            and   name  = 'IDX_TCB_BOR_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_J_TEMPSCOUBORNE_TCB.IDX_TCB_BOR_ID
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_J_TEMPSCOUBORNE_TCB')
            and   name  = 'IDX_TCB_COU_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_J_TEMPSCOUBORNE_TCB.IDX_TCB_COU_ID
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_J_TEMPSCOUBORNE_TCB')
            and   type = 'U')
   drop table T_J_TEMPSCOUBORNE_TCB
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_R_BORNE_BOR')
            and   name  = 'IDX_BOR_COR_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_R_BORNE_BOR.IDX_BOR_COR_ID
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_R_BORNE_BOR')
            and   type = 'U')
   drop table T_R_BORNE_BOR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_R_CATEGORIE_CAT')
            and   type = 'U')
   drop table T_R_CATEGORIE_CAT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_R_CLUB_CLU')
            and   type = 'U')
   drop table T_R_CLUB_CLU
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_R_COURSE_COR')
            and   type = 'U')
   drop table T_R_COURSE_COR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_R_DEFI_DEF')
            and   type = 'U')
   drop table T_R_DEFI_DEF
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('T_R_LOT_LOT')
            and   name  = 'IDX_LOT_COU_ID'
            and   indid > 0
            and   indid < 255)
   drop index T_R_LOT_LOT.IDX_LOT_COU_ID
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_R_LOT_LOT')
            and   type = 'U')
   drop table T_R_LOT_LOT
go

/*==============================================================*/
/* Table : T_E_CLASSEMENT_CLA                                   */
/*==============================================================*/
create table T_E_CLASSEMENT_CLA (
   CLA_ID               int                  not null,
   CLA_TEMPS            int                  null,
   constraint PK_T_E_CLASSEMENT_CLA primary key nonclustered (CLA_ID)
)
go

/*==============================================================*/
/* Table : T_E_COUREUR_COU                                      */
/*==============================================================*/
create table T_E_COUREUR_COU (
   COU_ID               int                  not null,
   CAT_ID               int                  not null,
   CLU_ID               int                  null,
   COU_PRENOM           varchar(255)         not null,
   COU_NOM              varchar(255)         not null,
   COU_DATENAISSANCE    datetime             not null,
   COU_SEXE             char(1)              not null,
   COU_NUMEROLICENCE    varchar(255)         not null,
   COU_FEDERATION       varchar(255)         not null,
   COU_EMAIL            varchar(255)         not null,
   COU_ADRESSE          varchar(255)         null,
   COU_CODEPOSTAL       char(5)              null,
   COU_VILLE            varchar(255)         null,
   COU_PAYS             varchar(255)         not null,
   COU_TELEPHONE        char(10)             not null,
   COU_FAX              char(10)             null,
   COU_ENTREPRISEGROUPEASSOCIATION varchar(255)         null,
   COU_CERTIFICATMEDICAL varchar(255)         null,
   constraint PK_T_E_COUREUR_COU primary key nonclustered (COU_ID)
)
go

/*==============================================================*/
/* Index : IDX_COU_CLU_ID                                       */
/*==============================================================*/
create index IDX_COU_CLU_ID on T_E_COUREUR_COU (
CLU_ID ASC
)
go

/*==============================================================*/
/* Index : IDX_COU_CAT_ID                                       */
/*==============================================================*/
create index IDX_COU_CAT_ID on T_E_COUREUR_COU (
CAT_ID ASC
)
go

/*==============================================================*/
/* Index : IDX_COU_COU_NOM                                      */
/*==============================================================*/
create index IDX_COU_COU_NOM on T_E_COUREUR_COU (
COU_NOM ASC
)
go

/*==============================================================*/
/* Index : IDX_COU_COU_PRENOM                                   */
/*==============================================================*/
create index IDX_COU_COU_PRENOM on T_E_COUREUR_COU (
COU_PRENOM ASC
)
go

/*==============================================================*/
/* Table : T_E_INFORMATIONPUBLIQUE_INF                          */
/*==============================================================*/
create table T_E_INFORMATIONPUBLIQUE_INF (
   INF_ID               int                  not null,
   INF_NOM              varchar(255)         null,
   INF_PRENOM           varchar(255)         null,
   INF_EMAIL            varchar(255)         not null,
   INF_CONTENUE         text                 not null,
   constraint PK_T_E_INFORMATIONPUBLIQUE_INF primary key nonclustered (INF_ID)
)
go

/*==============================================================*/
/* Table : T_E_INSCRIT_INS                                      */
/*==============================================================*/
create table T_E_INSCRIT_INS (
   INS_ID               int                  not null,
   INS_LOGIN            varchar(255)         not null,
   INS_MDP              varchar(255)         not null,
   INS_NIVEAUATHENTIFICATION int                  not null,
   constraint PK_T_E_INSCRIT_INS primary key nonclustered (INS_ID)
)
go

/*==============================================================*/
/* Table : T_E_PAIEMENT_PAI                                     */
/*==============================================================*/
create table T_E_PAIEMENT_PAI (
   PAI_ID               int                  not null,
   PAI_MONTANT          int                  not null,
   PAI_MOYENDEPAIEMENT  varchar(255)         null,
   PAI_DATEPAIEMENT     datetime             not null,
   constraint PK_T_E_PAIEMENT_PAI primary key nonclustered (PAI_ID)
)
go

/*==============================================================*/
/* Table : T_J_DEFICOURSE_DEC                                   */
/*==============================================================*/
create table T_J_DEFICOURSE_DEC (
   DEF_ID               int                  not null,
   COR_ID               int                  not null,
   constraint PK_T_J_DEFICOURSE_DEC primary key nonclustered (DEF_ID, COR_ID)
)
go

/*==============================================================*/
/* Index : IDX_DEC_DEF_ID                                       */
/*==============================================================*/
create index IDX_DEC_DEF_ID on T_J_DEFICOURSE_DEC (
DEF_ID ASC
)
go

/*==============================================================*/
/* Index : IDX_DEC_COR_ID                                       */
/*==============================================================*/
create index IDX_DEC_COR_ID on T_J_DEFICOURSE_DEC (
COR_ID ASC
)
go

/*==============================================================*/
/* Table : T_J_GENERATION_GEN                                   */
/*==============================================================*/
create table T_J_GENERATION_GEN (
   GEN_ID               int                  not null,
   COU_ID               int                  not null,
   CLA_ID               int                  not null,
   COR_ID               int                  not null,
   constraint PK_T_J_GENERATION_GEN primary key nonclustered (GEN_ID)
)
go

/*==============================================================*/
/* Index : IDX_GEN_COU_ID                                       */
/*==============================================================*/
create unique index IDX_GEN_COU_ID on T_J_GENERATION_GEN (
COU_ID ASC
)
go

/*==============================================================*/
/* Index : IDX_GEN_CLA_ID                                       */
/*==============================================================*/
create unique index IDX_GEN_CLA_ID on T_J_GENERATION_GEN (
CLA_ID ASC
)
go

/*==============================================================*/
/* Index : IDX_GEN_COR_ID                                       */
/*==============================================================*/
create unique index IDX_GEN_COR_ID on T_J_GENERATION_GEN (
COR_ID ASC
)
go

/*==============================================================*/
/* Table : T_J_PARTICIPATIONDEFI_PAD                            */
/*==============================================================*/
create table T_J_PARTICIPATIONDEFI_PAD (
   COU_ID               int                  not null,
   DEF_ID               int                  not null,
   constraint PK_T_J_PARTICIPATIONDEFI_PAD primary key nonclustered (COU_ID, DEF_ID)
)
go

/*==============================================================*/
/* Index : IDX_PAD_COU_ID                                       */
/*==============================================================*/
create index IDX_PAD_COU_ID on T_J_PARTICIPATIONDEFI_PAD (
COU_ID ASC
)
go

/*==============================================================*/
/* Index : IDX_PAD_DEF_ID                                       */
/*==============================================================*/
create index IDX_PAD_DEF_ID on T_J_PARTICIPATIONDEFI_PAD (
DEF_ID ASC
)
go

/*==============================================================*/
/* Table : T_J_PARTICIPATIONENGROUPE_PEG                        */
/*==============================================================*/
create table T_J_PARTICIPATIONENGROUPE_PEG (
   PEG_ID               int                  not null,
   COU_ID               int                  not null,
   CLU_ID               int                  not null,
   PAI_ID               int                  not null,
   PEG_NOMBREPARTICIPANT int                  null,
   PEG_NOMBREPASTAPARTY int                  null,
   constraint PK_T_J_PARTICIPATIONENGROUPE_P primary key nonclustered (PEG_ID)
)
go

/*==============================================================*/
/* Index : IDX_PEG_COU_ID                                       */
/*==============================================================*/
create unique index IDX_PEG_COU_ID on T_J_PARTICIPATIONENGROUPE_PEG (
COU_ID ASC
)
go

/*==============================================================*/
/* Index : IDX_PEG_CLU_ID                                       */
/*==============================================================*/
create unique index IDX_PEG_CLU_ID on T_J_PARTICIPATIONENGROUPE_PEG (
CLU_ID ASC
)
go

/*==============================================================*/
/* Index : IDX_PEG_PAI_ID                                       */
/*==============================================================*/
create unique index IDX_PEG_PAI_ID on T_J_PARTICIPATIONENGROUPE_PEG (
PAI_ID ASC
)
go

/*==============================================================*/
/* Table : T_J_PARTICIPATION_PAR                                */
/*==============================================================*/
create table T_J_PARTICIPATION_PAR (
   PAR_ID               int                  not null,
   COU_ID               int                  not null,
   COR_ID               int                  not null,
   PAI_ID               int                  not null,
   PAR_PASTAPARTY       bit                  null,
   PAR_TEMPSESTIME      int                  null,
   PAR_NOMBREPASTAPARTY int                  null,
   PAR_DOSSARD          int                  not null,
   constraint PK_T_J_PARTICIPATION_PAR primary key nonclustered (PAR_ID)
)
go

/*==============================================================*/
/* Index : IDX_PAR_COU_ID                                       */
/*==============================================================*/
create unique index IDX_PAR_COU_ID on T_J_PARTICIPATION_PAR (
COU_ID ASC
)
go

/*==============================================================*/
/* Index : IDX_PAR_COR_ID                                       */
/*==============================================================*/
create unique index IDX_PAR_COR_ID on T_J_PARTICIPATION_PAR (
COR_ID ASC
)
go

/*==============================================================*/
/* Index : IDX_PAR_PAI_ID                                       */
/*==============================================================*/
create unique index IDX_PAR_PAI_ID on T_J_PARTICIPATION_PAR (
PAI_ID ASC
)
go

/*==============================================================*/
/* Index : IDX_PAR_PAR_DOSSARD                                  */
/*==============================================================*/
create unique index IDX_PAR_PAR_DOSSARD on T_J_PARTICIPATION_PAR (
PAR_DOSSARD ASC
)
go

/*==============================================================*/
/* Table : T_J_TEMPSCOUBORNE_TCB                                */
/*==============================================================*/
create table T_J_TEMPSCOUBORNE_TCB (
   BOR_ID               int                  not null,
   COU_ID               int                  not null,
   TCB_TEMPS            int                  null,
   constraint PK_T_J_TEMPSCOUBORNE_TCB primary key nonclustered (BOR_ID, COU_ID)
)
go

/*==============================================================*/
/* Index : IDX_TCB_COU_ID                                       */
/*==============================================================*/
create index IDX_TCB_COU_ID on T_J_TEMPSCOUBORNE_TCB (
COU_ID ASC
)
go

/*==============================================================*/
/* Index : IDX_TCB_BOR_ID                                       */
/*==============================================================*/
create index IDX_TCB_BOR_ID on T_J_TEMPSCOUBORNE_TCB (
BOR_ID ASC
)
go

/*==============================================================*/
/* Table : T_R_BORNE_BOR                                        */
/*==============================================================*/
create table T_R_BORNE_BOR (
   BOR_ID               int                  not null,
   COR_ID               int                  not null,
   BOR_EMPLACEMENT      int                  not null,
   constraint PK_T_R_BORNE_BOR primary key nonclustered (BOR_ID)
)
go

/*==============================================================*/
/* Index : IDX_BOR_COR_ID                                       */
/*==============================================================*/
create index IDX_BOR_COR_ID on T_R_BORNE_BOR (
COR_ID ASC
)
go

/*==============================================================*/
/* Table : T_R_CATEGORIE_CAT                                    */
/*==============================================================*/
create table T_R_CATEGORIE_CAT (
   CAT_ID               int                  not null,
   CAT_LIBELLE          varchar(255)         null,
   constraint PK_T_R_CATEGORIE_CAT primary key nonclustered (CAT_ID)
)
go

/*==============================================================*/
/* Table : T_R_CLUB_CLU                                         */
/*==============================================================*/
create table T_R_CLUB_CLU (
   CLU_ID               int                  not null,
   CLU_NOM              varchar(255)         not null,
   CLU_LICENCE          int                  not null,
   CLU_EMAIL            varchar(255)         not null,
   constraint PK_T_R_CLUB_CLU primary key nonclustered (CLU_ID)
)
go

/*==============================================================*/
/* Table : T_R_COURSE_COR                                       */
/*==============================================================*/
create table T_R_COURSE_COR (
   COR_ID               int                  not null,
   COR_NOM              varchar(255)         not null,
   COR_DISTANCE         int                  not null,
   COR_DATE             datetime             null,
   COR_NOMBREMAXPARTICIPANT int                  null,
   COR_PRIX             decimal              null,
   constraint PK_T_R_COURSE_COR primary key nonclustered (COR_ID)
)
go

/*==============================================================*/
/* Table : T_R_DEFI_DEF                                         */
/*==============================================================*/
create table T_R_DEFI_DEF (
   DEF_ID               int                  not null,
   DEF_NOM              text                 not null,
   DEF_NOMBREMAXPARTICIPANT int                  not null,
   constraint PK_T_R_DEFI_DEF primary key nonclustered (DEF_ID)
)
go

/*==============================================================*/
/* Table : T_R_LOT_LOT                                          */
/*==============================================================*/
create table T_R_LOT_LOT (
   LOT_ID               int                  not null,
   COU_ID               int                  null,
   LOT_NOM              varchar(255)         null,
   constraint PK_T_R_LOT_LOT primary key nonclustered (LOT_ID)
)
go

/*==============================================================*/
/* Index : IDX_LOT_COU_ID                                       */
/*==============================================================*/
create index IDX_LOT_COU_ID on T_R_LOT_LOT (
COU_ID ASC
)
go

alter table T_E_COUREUR_COU
   add constraint FK_T_E_COUR_EST_AFFIL_T_R_CLUB foreign key (CLU_ID)
      references T_R_CLUB_CLU (CLU_ID)
go

alter table T_E_COUREUR_COU
   add constraint FK_T_E_COUR_EST_DEFIN_T_R_CATE foreign key (CAT_ID)
      references T_R_CATEGORIE_CAT (CAT_ID)
go

alter table T_J_DEFICOURSE_DEC
   add constraint FK_T_J_DEFI_CONTIENT_T_R_DEFI foreign key (DEF_ID)
      references T_R_DEFI_DEF (DEF_ID)
go

alter table T_J_DEFICOURSE_DEC
   add constraint FK_T_J_DEFI_CONTIENT2_T_R_COUR foreign key (COR_ID)
      references T_R_COURSE_COR (COR_ID)
go

alter table T_J_GENERATION_GEN
   add constraint FK_T_J_GENE_GENERE_T_E_COUR foreign key (COU_ID)
      references T_E_COUREUR_COU (COU_ID)
go

alter table T_J_GENERATION_GEN
   add constraint FK_T_J_GENE_GENERE2_T_E_CLAS foreign key (CLA_ID)
      references T_E_CLASSEMENT_CLA (CLA_ID)
go

alter table T_J_GENERATION_GEN
   add constraint FK_T_J_GENE_GENERE3_T_R_COUR foreign key (COR_ID)
      references T_R_COURSE_COR (COR_ID)
go

alter table T_J_PARTICIPATIONDEFI_PAD
   add constraint FK_T_J_PART_PARTICIPE_T_E_COUR foreign key (COU_ID)
      references T_E_COUREUR_COU (COU_ID)
go

alter table T_J_PARTICIPATIONDEFI_PAD
   add constraint FK_T_J_PART_PARTICIPE_T_R_DEFI foreign key (DEF_ID)
      references T_R_DEFI_DEF (DEF_ID)
go

alter table T_J_PARTICIPATIONENGROUPE_PEG
   add constraint FK_T_J_PART_PARTICIPE_T_R_COUR foreign key (COU_ID)
      references T_R_COURSE_COR (COR_ID)
go

alter table T_J_PARTICIPATIONENGROUPE_PEG
   add constraint FK_T_J_PART_PARTICIPE_T_R_CLUB foreign key (CLU_ID)
      references T_R_CLUB_CLU (CLU_ID)
go

alter table T_J_PARTICIPATIONENGROUPE_PEG
   add constraint FK_T_J_PART_PARTICIPE_T_E_PAIE foreign key (PAI_ID)
      references T_E_PAIEMENT_PAI (PAI_ID)
go

alter table T_J_PARTICIPATION_PAR
   add constraint FK_PART_COU foreign key (COU_ID)
      references T_E_COUREUR_COU (COU_ID)
go

alter table T_J_PARTICIPATION_PAR
   add constraint FK_PART_COR foreign key (COR_ID)
      references T_R_COURSE_COR (COR_ID)
go

alter table T_J_PARTICIPATION_PAR
   add constraint FK_PART_PAI foreign key (PAI_ID)
      references T_E_PAIEMENT_PAI (PAI_ID)
go

alter table T_J_TEMPSCOUBORNE_TCB
   add constraint FK_T_J_TEMP_DISTRIBUE_T_E_COUR foreign key (COU_ID)
      references T_E_COUREUR_COU (COU_ID)
go

alter table T_J_TEMPSCOUBORNE_TCB
   add constraint FK_T_J_TEMP_EST_COMPO_T_R_BORN foreign key (BOR_ID)
      references T_R_BORNE_BOR (BOR_ID)
go

alter table T_R_BORNE_BOR
   add constraint FK_T_R_BORN_EST_COMPO_T_R_COUR foreign key (COR_ID)
      references T_R_COURSE_COR (COR_ID)
go

alter table T_R_LOT_LOT
   add constraint FK_T_R_LOT__DISTRIBUE_T_E_COUR foreign key (COU_ID)
      references T_E_COUREUR_COU (COU_ID)
go

