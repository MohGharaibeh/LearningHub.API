﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearningHub.core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apicategory> Apicategories { get; set; } = null!;
        public virtual DbSet<Apicourse> Apicourses { get; set; } = null!;
        public virtual DbSet<Apilogin> Apilogins { get; set; } = null!;
        public virtual DbSet<Apirole> Apiroles { get; set; } = null!;
        public virtual DbSet<Apistdcourse> Apistdcourses { get; set; } = null!;
        public virtual DbSet<Apistudent> Apistudents { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("DATA SOURCE=DESKTOP-P1MURAO:1522/xe;USER ID=sys;PASSWORD=123;DBA PRIVILEGE=SYSDBA;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SYS")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Apicategory>(entity =>
            {
                entity.HasKey(e => e.Categoryid)
                    .HasName("SYS_C008342");

                entity.ToTable("APICATEGORY");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYNAME");
            });

            modelBuilder.Entity<Apicourse>(entity =>
            {
                entity.HasKey(e => e.Courseid)
                    .HasName("SYS_C008344");

                entity.ToTable("APICOURSE");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Courseimagepath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("COURSEIMAGEPATH");

                entity.Property(e => e.Coursename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COURSENAME");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Apicourses)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("CAT_FK");
            });

            modelBuilder.Entity<Apilogin>(entity =>
            {
                entity.HasKey(e => e.Loginid)
                    .HasName("SYS_C008338");

                entity.ToTable("APILOGIN");

                entity.Property(e => e.Loginid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGINID");

                entity.Property(e => e.Loginpassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOGINPASSWORD");

                entity.Property(e => e.Loginusername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOGINUSERNAME");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("STUDENTID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Apilogins)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ROLE_FK");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Apilogins)
                    .HasForeignKey(d => d.Studentid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("STD_FK");
            });

            modelBuilder.Entity<Apirole>(entity =>
            {
                entity.HasKey(e => e.Roleid)
                    .HasName("SYS_C008334");

                entity.ToTable("APIROLE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Apistdcourse>(entity =>
            {
                entity.HasKey(e => e.Stdcourseid)
                    .HasName("SYS_C008347");

                entity.ToTable("APISTDCOURSE");

                entity.Property(e => e.Stdcourseid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STDCOURSEID");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Stdcoursedateofregistration)
                    .HasColumnType("DATE")
                    .HasColumnName("STDCOURSEDATEOFREGISTRATION");

                entity.Property(e => e.Stdcoursemarkofstd)
                    .HasColumnType("FLOAT")
                    .HasColumnName("STDCOURSEMARKOFSTD");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("STUDENTID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Apistdcourses)
                    .HasForeignKey(d => d.Courseid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("CORS_FK");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Apistdcourses)
                    .HasForeignKey(d => d.Studentid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("STUD_FK");
            });

            modelBuilder.Entity<Apistudent>(entity =>
            {
                entity.HasKey(e => e.Studentid)
                    .HasName("SYS_C008336");

                entity.ToTable("APISTUDENT");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STUDENTID");

                entity.Property(e => e.Studentdateofbirth)
                    .HasColumnType("DATE")
                    .HasColumnName("STUDENTDATEOFBIRTH");

                entity.Property(e => e.Studentfirstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STUDENTFIRSTNAME");

                entity.Property(e => e.Studentlastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STUDENTLASTNAME");
            });

            modelBuilder.HasSequence("ACTIVITY_SNAP_SEQ$");

            modelBuilder.HasSequence("ADO_IMCSEQ$");

            modelBuilder.HasSequence("APP$SYSTEM$SEQ");

            modelBuilder.HasSequence("APPLY$_DEST_OBJ_ID");

            modelBuilder.HasSequence("APPLY$_ERROR_HANDLER_SEQUENCE");

            modelBuilder.HasSequence("APPLY$_SOURCE_OBJ_ID");

            modelBuilder.HasSequence("AQ$_ALERT_QT_N");

            modelBuilder.HasSequence("AQ$_AQ_PROP_TABLE_N");

            modelBuilder.HasSequence("AQ$_AQ$_MEM_MC_N");

            modelBuilder.HasSequence("AQ$_CHAINSEQ");

            modelBuilder.HasSequence("AQ$_IOTENQTXID");

            modelBuilder.HasSequence("AQ$_NONDURSUB_SEQUENCE");

            modelBuilder.HasSequence("AQ$_ORA$PREPLUGIN_BACKUP_QTB_N");

            modelBuilder.HasSequence("AQ$_PDB_MON_EVENT_QTABLE$_N");

            modelBuilder.HasSequence("AQ$_PROPAGATION_SEQUENCE");

            modelBuilder.HasSequence("AQ$_PUBLISHER_SEQUENCE");

            modelBuilder.HasSequence("AQ$_RULE_SEQUENCE");

            modelBuilder.HasSequence("AQ$_RULE_SET_SEQUENCE");

            modelBuilder.HasSequence("AQ$_SCHEDULER_FILEWATCHER_QT_N");

            modelBuilder.HasSequence("AQ$_SCHEDULER$_EVENT_QTAB_N");

            modelBuilder.HasSequence("AQ$_SCHEDULER$_REMDB_JOBQTAB_N");

            modelBuilder.HasSequence("AQ$_SYS$SERVICE_METRICS_TAB_N");

            modelBuilder.HasSequence("AQ$_TRANS_SEQUENCE");

            modelBuilder.HasSequence("AUDSES$").IsCyclic();

            modelBuilder.HasSequence("AWCREATE_S$");

            modelBuilder.HasSequence("AWCREATE10G_S$");

            modelBuilder.HasSequence("AWLOGSEQ$");

            modelBuilder.HasSequence("AWMD_S$");

            modelBuilder.HasSequence("AWREPORT_S$");

            modelBuilder.HasSequence("AWSEQ$");

            modelBuilder.HasSequence("AWXML_S$");

            modelBuilder.HasSequence("CACHE_STATS_SEQ_0");

            modelBuilder.HasSequence("CACHE_STATS_SEQ_1");

            modelBuilder.HasSequence("CDC_RSID_SEQ$");

            modelBuilder.HasSequence("CHNF$_CLAUSEID_SEQ");

            modelBuilder.HasSequence("CHNF$_QUERYID_SEQ");

            modelBuilder.HasSequence("CLI_ID$");

            modelBuilder.HasSequence("COMPARISON_SCAN_SEQ$").IsCyclic();

            modelBuilder.HasSequence("COMPARISON_SEQ$");

            modelBuilder.HasSequence("CONFLICT_HANDLER_ID_SEQ$");

            modelBuilder.HasSequence("CONS_LOGSEQ");

            modelBuilder.HasSequence("DAM_CLEANUP_SEQ$");

            modelBuilder.HasSequence("DBFS_HS$_ARCHIVEREFIDSEQ");

            modelBuilder.HasSequence("DBFS_HS$_BACKUPFILEIDSEQ");

            modelBuilder.HasSequence("DBFS_HS$_POLICYIDSEQ");

            modelBuilder.HasSequence("DBFS_HS$_RSEQ");

            modelBuilder.HasSequence("DBFS_HS$_STOREIDSEQ");

            modelBuilder.HasSequence("DBFS_HS$_TARBALLSEQ");

            modelBuilder.HasSequence("DBFS_SFS$_FSSEQ");

            modelBuilder.HasSequence("DBMS_CUBE_ADVICE_SEQ$").IsCyclic();

            modelBuilder.HasSequence("DBMS_LOCK_ID_V2").IsCyclic();

            modelBuilder.HasSequence("DBMS_PARALLEL_EXECUTE_SEQ$");

            modelBuilder.HasSequence("DM$EXPIMP_ID_SEQ");

            modelBuilder.HasSequence("EXPRESS_S$");

            modelBuilder.HasSequence("FED$APPID_SEQ");

            modelBuilder.HasSequence("FED$SESS_SEQ");

            modelBuilder.HasSequence("FED$STMT_SEQ");

            modelBuilder.HasSequence("FGR$_NAMES_S");

            modelBuilder.HasSequence("GROUP_NUM_SEQ");

            modelBuilder.HasSequence("HS$_BASE_DD_S");

            modelBuilder.HasSequence("HS$_CLASS_CAPS_S");

            modelBuilder.HasSequence("HS$_CLASS_DD_S");

            modelBuilder.HasSequence("HS$_CLASS_INIT_S");

            modelBuilder.HasSequence("HS$_FDS_CLASS_S");

            modelBuilder.HasSequence("HS$_FDS_INST_S");

            modelBuilder.HasSequence("HS$_INST_CAPS_S");

            modelBuilder.HasSequence("HS$_INST_DD_S");

            modelBuilder.HasSequence("HS$_INST_INIT_S");

            modelBuilder.HasSequence("IDGEN1$").IncrementsBy(50);

            modelBuilder.HasSequence("IDX_RB$JOBSEQ").IsCyclic();

            modelBuilder.HasSequence("ILM_EXECUTIONID");

            modelBuilder.HasSequence("ILM_SEQ$");

            modelBuilder.HasSequence("IM_DOMAINSEQ$");

            modelBuilder.HasSequence("INVALIDATION_REG_ID$");

            modelBuilder.HasSequence("JAVA$JOX$CUJS$SEQUENCE$");

            modelBuilder.HasSequence("JAVA$POLICY$SEQUENCE$");

            modelBuilder.HasSequence("JAVA$PREFS$SEQ$").IsCyclic();

            modelBuilder.HasSequence("JOBSEQ").IsCyclic();

            modelBuilder.HasSequence("JOBSEQLSBY").IsCyclic();

            modelBuilder.HasSequence("LINK_SOURCE_ID_SEQ");

            modelBuilder.HasSequence("LOG$SEQUENCE");

            modelBuilder.HasSequence("MAINTPLAN_SEQ");

            modelBuilder.HasSequence("MODELALG_SEQ$");

            modelBuilder.HasSequence("MV_RF$JOBSEQ").IsCyclic();

            modelBuilder.HasSequence("MV_RF$USAGESTATSEQ").IsCyclic();

            modelBuilder.HasSequence("MVREF$_STATS_SEQ");

            modelBuilder.HasSequence("OBJECT_GRANT");

            modelBuilder.HasSequence("OLAP_ASSIGNMENTS_SEQ");

            modelBuilder.HasSequence("OLAP_ATTRIBUTES_SEQ");

            modelBuilder.HasSequence("OLAP_CALCULATED_MEMBERS_SEQ");

            modelBuilder.HasSequence("OLAP_DIM_LEVELS_SEQ");

            modelBuilder.HasSequence("OLAP_DIMENSIONALITY_SEQ");

            modelBuilder.HasSequence("OLAP_HIER_LEVELS_SEQ");

            modelBuilder.HasSequence("OLAP_HIERARCHIES_SEQ");

            modelBuilder.HasSequence("OLAP_MAPPINGS_SEQ");

            modelBuilder.HasSequence("OLAP_MEASURES_SEQ");

            modelBuilder.HasSequence("OLAP_MODELS_SEQ");

            modelBuilder.HasSequence("OLAP_PROPERTIES_SEQ");

            modelBuilder.HasSequence("ORA_PLAN_ID_SEQ$").IsCyclic();

            modelBuilder.HasSequence("ORA_TQ_BASE$").IsCyclic();

            modelBuilder.HasSequence("PARTITION_NAME$");

            modelBuilder.HasSequence("PCLX_JOBSEQ").IsCyclic();

            modelBuilder.HasSequence("PDB_ALERT_SEQUENCE").IsCyclic();

            modelBuilder.HasSequence("PLSQL_CODE_COVERAGE_RUNNUMBER");

            modelBuilder.HasSequence("PRIV_CAPTURE_SEQ$");

            modelBuilder.HasSequence("PRIV_UNUSED_ID$");

            modelBuilder.HasSequence("PRIV_USED_ID$");

            modelBuilder.HasSequence("PROFNUM$");

            modelBuilder.HasSequence("PSINDEX_SEQ$");

            modelBuilder.HasSequence("RADM_PE$_SEQ");

            modelBuilder.HasSequence("REDEF_SEQ$");

            modelBuilder.HasSequence("RGROUPSEQ").IsCyclic();

            modelBuilder.HasSequence("RULE_ID_SEQ$").IsCyclic();

            modelBuilder.HasSequence("SCHEDULER$_EVTSEQ");

            modelBuilder.HasSequence("SCHEDULER$_INSTANCE_S");

            modelBuilder.HasSequence("SCHEDULER$_JOBSUFFIX_S");

            modelBuilder.HasSequence("SCHEDULER$_LWJOB_OID_SEQ");

            modelBuilder.HasSequence("SCHEDULER$_RDB_SEQ");

            modelBuilder.HasSequence("SNAPSHOT_ID$");

            modelBuilder.HasSequence("SNAPSITE_ID$");

            modelBuilder.HasSequence("SQL_TK_CHK_ID");

            modelBuilder.HasSequence("SQLLOG$_SEQ").IsCyclic();

            modelBuilder.HasSequence("SSCR_CAP_SEQ$");

            modelBuilder.HasSequence("ST_OPR_ID_SEQ");

            modelBuilder.HasSequence("STATS_ADVISOR_DIR_SEQ");

            modelBuilder.HasSequence("STREAMS$_APPLY_SPILL_TXNKEY_S").IsCyclic();

            modelBuilder.HasSequence("STREAMS$_CAP_SUB_INST").IsCyclic();

            modelBuilder.HasSequence("STREAMS$_CAPTURE_INST").IsCyclic();

            modelBuilder.HasSequence("STREAMS$_PROPAGATION_SEQNUM");

            modelBuilder.HasSequence("STREAMS$_RULE_NAME_S");

            modelBuilder.HasSequence("STREAMS$_SM_ID");

            modelBuilder.HasSequence("STREAMS$_STMT_HANDLER_SEQ");

            modelBuilder.HasSequence("SWAT_MM_REFRESH_ID_SEQ$");

            modelBuilder.HasSequence("SYNCREF_GROUP_ID_SEQ$");

            modelBuilder.HasSequence("SYNCREF_STEP_SEQ$");

            modelBuilder.HasSequence("SYNOPSIS_NUM_SEQ");

            modelBuilder.HasSequence("SYSDBIMFSCUID_SEQ$");

            modelBuilder.HasSequence("SYSDBIMFSSEG_SEQ$");

            modelBuilder.HasSequence("SYSLSBY_EDS_DDL_SEQ").IsCyclic();

            modelBuilder.HasSequence("SYSTEM_GRANT");

            modelBuilder.HasSequence("TSDP_ASSOCIATION$SEQUENCE");

            modelBuilder.HasSequence("TSDP_POLICY$SEQUENCE");

            modelBuilder.HasSequence("TSDP_POLNAME$SEQUENCE");

            modelBuilder.HasSequence("TSDP_PROTECTION$SEQUENCE");

            modelBuilder.HasSequence("TSDP_SENSITIVE$SEQUENCE");

            modelBuilder.HasSequence("TSDP_SOURCE$SEQUENCE");

            modelBuilder.HasSequence("TSDP_SUBPOL$SEQUENCE");

            modelBuilder.HasSequence("TSDP_TYPE$SEQUENCE");

            modelBuilder.HasSequence("TSM_MIG_SEQ$");

            modelBuilder.HasSequence("UGROUP_SEQUENCE");

            modelBuilder.HasSequence("UMF_EVTLOG_LOG_ID_SEQ").IsCyclic();

            modelBuilder.HasSequence("USER_GRANT");

            modelBuilder.HasSequence("UTL_RECOMP_SEQ");

            modelBuilder.HasSequence("WI$_JOB_ID");

            modelBuilder.HasSequence("WRI$_ADV_SEQ_DIR");

            modelBuilder.HasSequence("WRI$_ADV_SEQ_DIR_INST");

            modelBuilder.HasSequence("WRI$_ADV_SEQ_EXEC");

            modelBuilder.HasSequence("WRI$_ADV_SEQ_JOURNAL");

            modelBuilder.HasSequence("WRI$_ADV_SEQ_MSGGROUP");

            modelBuilder.HasSequence("WRI$_ADV_SEQ_SQLW_QUERY");

            modelBuilder.HasSequence("WRI$_ADV_SEQ_TASK");

            modelBuilder.HasSequence("WRI$_ADV_SQLT_PLAN_SEQ");

            modelBuilder.HasSequence("WRI$_ALERT_SEQUENCE");

            modelBuilder.HasSequence("WRI$_ALERT_THRSLOG_SEQUENCE");

            modelBuilder.HasSequence("WRI$_EMX_FILE_ID_SEQ");

            modelBuilder.HasSequence("WRI$_REPT_COMP_ID_SEQ");

            modelBuilder.HasSequence("WRI$_REPT_FORMAT_ID_SEQ");

            modelBuilder.HasSequence("WRI$_REPT_REPT_ID_SEQ");

            modelBuilder.HasSequence("WRI$_SQLSET_ID_SEQ");

            modelBuilder.HasSequence("WRI$_SQLSET_RATMASK_SEQ");

            modelBuilder.HasSequence("WRI$_SQLSET_REF_ID_SEQ");

            modelBuilder.HasSequence("WRI$_SQLSET_STMT_ID_SEQ");

            modelBuilder.HasSequence("WRI$_SQLSET_WORKSPACE_PLAN_SEQ");

            modelBuilder.HasSequence("WRM$_DEEP_PURGE_INTERVAL").IsCyclic();

            modelBuilder.HasSequence("WRP$_REPORT_ID_SEQ");

            modelBuilder.HasSequence("WRR$_CAPTURE_ID");

            modelBuilder.HasSequence("WRR$_REPLAY_ID");

            modelBuilder.HasSequence("WRW_EXP_MAILPKG_SEQ").IsCyclic();

            modelBuilder.HasSequence("WRW_IMP_LEGACY_MAILPKG_SEQ").IsCyclic();

            modelBuilder.HasSequence("WRW_IMPID_SEQ").IsCyclic();

            modelBuilder.HasSequence("XS$ID_SEQUENCE");

            modelBuilder.HasSequence("XSPARAM_REG_SEQUENCE$");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
