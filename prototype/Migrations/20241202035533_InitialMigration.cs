using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prototype.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasicInformations");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "PersonalInformations");

            migrationBuilder.DropTable(
                name: "PersonInCaseOfEmergency");

            migrationBuilder.DropColumn(
                name: "OTP",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "REFERENCE_STATUS",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "OTP",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "REFERENCE_STATUS",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "USERID");

            migrationBuilder.CreateTable(
                name: "BASIC_INFORMATION",
                columns: table => new
                {
                    BASIC_INFO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACCREDITATION_OF_SUBJECTS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APPLICATION_DATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APPLYING_AS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BI_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LRN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STRAND = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TRACK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_CAMPUS1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_CAMPUS2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_CAMPUS3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_COURSE1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_COURSE2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_COURSE3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CURRENTLY_ENROLLED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NAME_OF_SCHOOL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASIC_INFORMATION", x => x.BASIC_INFO_ID);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Building_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Building_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Building_Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Building_ID);
                });

            migrationBuilder.CreateTable(
                name: "EDUCATION",
                columns: table => new
                {
                    EDUCATION_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COLLEGE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_COURSE_YR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_DATE_GRADUATED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_HONORS_RECEIVED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_LOCATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_SCHOOL_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TECH_VOC_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_COURSE_YR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_DATE_GRADUATED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_HONORS_RECEIVED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_LOCATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_SCHOOL_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_CURRICULUM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HIGH_SCHOOL_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_COURSE_YR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_DATE_GRADUATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_HONORS_RECEIVED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_LOCATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_SCHOOL_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_CURRICULUM = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDUCATION", x => x.EDUCATION_ID);
                });

            migrationBuilder.CreateTable(
                name: "FAMILY",
                columns: table => new
                {
                    FAMILY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_MIDDLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_SUFFIX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_OCCUPATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_EDUCATIONAL_ATTAINMENT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_CONTACT_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_MIDDLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_CONTACT_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_EDUCATIONAL_ATTAINMENT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_OCCUPATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FAMILY_BARANGAY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FAMILY_DISTRICT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FAMILY_MUNICIPALITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FAMILY_STREET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FAMILY_ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_MIDDLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_SUFFIX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_CONTACT_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_RELATIONSHIP = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAMILY", x => x.FAMILY_ID);
                });

            migrationBuilder.CreateTable(
                name: "PERSON_INCASEOF_EMERGENCY",
                columns: table => new
                {
                    PICOE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PICOE_FIRSTNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_MIDDLENAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_LASTNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_SUFFIX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_CONTACTNUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_HOUSESTREET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_BRGY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_DISTRICT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_MUNICIPALITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_RELATIONSHIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSON_INCASEOF_EMERGENCY", x => x.PICOE_ID);
                });

            migrationBuilder.CreateTable(
                name: "PERSONAL_INFORMATION",
                columns: table => new
                {
                    PERSONAL_INFO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIDDLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUFFIX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_OF_BIRTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BIRTH_PLACE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GENDER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RELIGION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CITIZENSHIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIVIL_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BARANGAY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DISTRICT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MUNICIPALITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STREET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONAL_INFORMATION", x => x.PERSONAL_INFO_ID);
                });

            migrationBuilder.CreateTable(
                name: "SCHEDULE",
                columns: table => new
                {
                    SCHEDULE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YEAR_SEM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SECTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUBJECT_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUBJECT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TIME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DAY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LECTURE_LAB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ROOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BUILDING = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHEDULE", x => x.SCHEDULE_ID);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SECTION_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SECTION_YEAR_SEM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SECTION_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SECTION_SLOT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MAX_CAPACITY = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SECTION_ID);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT_ENLISTMENT",
                columns: table => new
                {
                    STUDENT_ENLISTMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SEF_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SEF_ID_PICTURE = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT_ENLISTMENT", x => x.STUDENT_ENLISTMENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT_GRADES",
                columns: table => new
                {
                    GRADES_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GRADES_STUDENT_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GRADE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUBJECT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TOTAL_UNITS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UNITS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GWA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REMARKS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT_GRADES", x => x.GRADES_ID);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT_REFERENCE",
                columns: table => new
                {
                    STUDENT_REF_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SR_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCE_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_TIME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT_REFERENCE", x => x.STUDENT_REF_ID);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT_YR_SCREENING",
                columns: table => new
                {
                    STUDENT_YR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SYC_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APPLYING_AS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACADEMIC_FROM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACADEMIC_TO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROGRAMS_OFFER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YR_LEVEL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YR_TERM = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT_YR_SCREENING", x => x.STUDENT_YR_ID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Room_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Building_ID = table.Column<int>(type: "int", nullable: false),
                    Room_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Room_No = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Room_ID);
                    table.ForeignKey(
                        name: "FK_Rooms_Buildings_Building_ID",
                        column: x => x.Building_ID,
                        principalTable: "Buildings",
                        principalColumn: "Building_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Building_ID",
                table: "Rooms",
                column: "Building_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BASIC_INFORMATION");

            migrationBuilder.DropTable(
                name: "EDUCATION");

            migrationBuilder.DropTable(
                name: "FAMILY");

            migrationBuilder.DropTable(
                name: "PERSON_INCASEOF_EMERGENCY");

            migrationBuilder.DropTable(
                name: "PERSONAL_INFORMATION");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "SCHEDULE");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "STUDENT_ENLISTMENT");

            migrationBuilder.DropTable(
                name: "STUDENT_GRADES");

            migrationBuilder.DropTable(
                name: "STUDENT_REFERENCE");

            migrationBuilder.DropTable(
                name: "STUDENT_YR_SCREENING");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.RenameColumn(
                name: "USERID",
                table: "Users",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "OTP",
                table: "USERS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "REFERENCE_STATUS",
                table: "USERS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OTP",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "REFERENCE_STATUS",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BasicInformations",
                columns: table => new
                {
                    BASIC_INFO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACCREDITATION_OF_SUBJECTS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APPLICATION_DATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APPLYING_AS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BI_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LRN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_CAMPUS1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_CAMPUS2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_CAMPUS3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_COURSE1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_COURSE2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PREFERRED_COURSE3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STRAND = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TRACK = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicInformations", x => x.BASIC_INFO_ID);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    COLLEGE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COLLEGE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_COURSE_YR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_DATE_GRADUATED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_HONORS_RECEIVED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_LOCATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_SCHOOL_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HIGH_SCHOOL_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_COURSE_YR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_DATE_GRADUATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_HONORS_RECEIVED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_ID = table.Column<int>(type: "int", nullable: false),
                    HS_LOCATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HS_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PERSONAL_INFO_ID = table.Column<int>(type: "int", nullable: false),
                    TECH_VOC_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_COURSE_YR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_DATE_GRADUATED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_HONORS_RECEIVED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_ID = table.Column<int>(type: "int", nullable: false),
                    TV_LOCATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TV_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.COLLEGE_ID);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    FAMILY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FATHER_BARANGAY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_CONTACT_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_DISTRICT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_EDUCATIONAL_ATTAINMENT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_MIDDLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_MUNICIPALITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_OCCUPATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_STREET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_SUFFIX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATHER_ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_BARANGAY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_CONTACT_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_DISTRICT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_MIDDLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_MUNICIPALITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_RELATIONSHIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_STREET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_SUFFIX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUARDIAN_ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_BARANGAY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_CONTACT_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_DISTRICT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_EDUCATIONAL_ATTAINMENT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_MIDDLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_MUNICIPALITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_OCCUPATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_STREET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOTHER_ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.FAMILY_ID);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformations",
                columns: table => new
                {
                    PERSONAL_INFO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BARANGAY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BIRTH_PLACE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CITIZENSHIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIVIL_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_OF_BIRTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DISTRICT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GENDER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HOUSE_STREET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIDDLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MUNICIPALITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RELIGION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUFFIX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformations", x => x.PERSONAL_INFO_ID);
                });

            migrationBuilder.CreateTable(
                name: "PersonInCaseOfEmergency",
                columns: table => new
                {
                    PICOE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PICOE_BRGY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_CONTACTNUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_DISTRICT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_FIRSTNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_HOUSESTREET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_LASTNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_MIDDLENAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_MUNICIPALITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_RELATIONSHIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_STUDENT_ACC_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_SUFFIX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PICOE_ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInCaseOfEmergency", x => x.PICOE_ID);
                });
        }
    }
}
