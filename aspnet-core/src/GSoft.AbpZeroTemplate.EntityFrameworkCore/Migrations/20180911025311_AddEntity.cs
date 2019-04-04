using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class AddEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BrowserInfo",
                table: "AbpUserLoginAttempts",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BrowserInfo",
                table: "AbpEntityChangeSets",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BrowserInfo",
                table: "AbpAuditLogs",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AdsPages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdsPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlepayTransactionInfos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    transactionCode = table.Column<string>(nullable: true),
                    orderCode = table.Column<string>(nullable: true),
                    amount = table.Column<string>(nullable: true),
                    currency = table.Column<string>(nullable: true),
                    buyerEmail = table.Column<string>(nullable: true),
                    buyerPhone = table.Column<string>(nullable: true),
                    cardNumber = table.Column<string>(nullable: true),
                    buyerName = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    message = table.Column<string>(nullable: true),
                    installment = table.Column<string>(nullable: true),
                    is3D = table.Column<string>(nullable: true),
                    month = table.Column<string>(nullable: true),
                    bankCode = table.Column<string>(nullable: true),
                    bankName = table.Column<string>(nullable: true),
                    method = table.Column<string>(nullable: true),
                    transactionTime = table.Column<string>(nullable: true),
                    successTime = table.Column<string>(nullable: true),
                    bankHotline = table.Column<string>(nullable: true),
                    alepayToken = table.Column<string>(nullable: true),
                    errorCode = table.Column<string>(nullable: true),
                    cancel = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    Data1 = table.Column<string>(nullable: true),
                    Data2 = table.Column<string>(nullable: true),
                    IdUser = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IdPackagePrices = table.Column<int>(nullable: true),
                    CodePricesPackages = table.Column<string>(nullable: true),
                    RECORD_STATUS = table.Column<string>(nullable: true),
                    AUTH_STATUS = table.Column<string>(nullable: true),
                    MAKER_ID = table.Column<string>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CHECKER_ID = table.Column<string>(nullable: true),
                    APPROVE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    EDITOR_ID = table.Column<string>(nullable: true),
                    EDIT_DT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlepayTransactionInfos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    FullName = table.Column<string>(maxLength: 256, nullable: true),
                    Address = table.Column<string>(maxLength: 256, nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Gender = table.Column<bool>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEndDateUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    StatusFramework = table.Column<bool>(nullable: true),
                    DXSurrogate = table.Column<string>(nullable: true),
                    Surrogate = table.Column<string>(nullable: true),
                    DXContactPerson = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    ContractID = table.Column<string>(nullable: true),
                    TaxCode = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: true),
                    ExpContract = table.Column<int>(nullable: true),
                    SignContractDT = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChargeDT = table.Column<DateTime>(type: "datetime", nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    RecordStatus = table.Column<string>(nullable: true),
                    MakerID = table.Column<string>(nullable: true),
                    DepID = table.Column<string>(nullable: true),
                    CreateDT = table.Column<DateTime>(type: "datetime", nullable: true),
                    AuthStatus = table.Column<string>(nullable: true),
                    CheckID = table.Column<string>(nullable: true),
                    ApproveDT = table.Column<DateTime>(type: "datetime", nullable: true),
                    EditorID = table.Column<string>(nullable: true),
                    EditorDT = table.Column<DateTime>(type: "datetime", nullable: true),
                    XmlTemp = table.Column<string>(nullable: true),
                    DataTemp = table.Column<string>(nullable: true),
                    ActiveDT = table.Column<DateTime>(type: "datetime", nullable: true),
                    ExpireDT = table.Column<DateTime>(type: "datetime", nullable: true),
                    Website = table.Column<string>(nullable: true),
                    FtpUser = table.Column<string>(nullable: true),
                    FtpPassword = table.Column<string>(nullable: true),
                    LinkAzure = table.Column<string>(nullable: true),
                    SqlUser = table.Column<string>(nullable: true),
                    SqlPass = table.Column<string>(nullable: true),
                    ValueString1 = table.Column<string>(nullable: true),
                    ValueString2 = table.Column<string>(nullable: true),
                    PriceCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Code = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 250, nullable: true),
                    Website = table.Column<string>(maxLength: 250, nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: true),
                    Other = table.Column<string>(nullable: true),
                    Lat = table.Column<double>(nullable: true),
                    Lng = table.Column<double>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DemoTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoTests", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "Errors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: true),
                    Message = table.Column<string>(maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    ID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    URL = table.Column<string>(maxLength: 256, nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    ParentId = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    IconCss = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dbo.Functions_dbo.Functions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Functions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuClients",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Alias = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    HomeOrder = table.Column<int>(nullable: true),
                    Image = table.Column<string>(maxLength: 256, nullable: true),
                    HomeFlag = table.Column<bool>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    MetaKeyword = table.Column<string>(maxLength: 256, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuClients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderPackages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUser = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime", nullable: true),
                    SumRegister = table.Column<decimal>(type: "money", nullable: false),
                    SumCheckout = table.Column<decimal>(type: "money", nullable: false),
                    PaymentMethod = table.Column<string>(maxLength: 256, nullable: true),
                    PaymentStatus = table.Column<string>(nullable: true),
                    IdPackagePrices = table.Column<int>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    Data1 = table.Column<string>(nullable: true),
                    Data2 = table.Column<string>(nullable: true),
                    CodePricesPackages = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    RECORD_STATUS = table.Column<string>(nullable: true),
                    AUTH_STATUS = table.Column<string>(nullable: true),
                    MAKER_ID = table.Column<string>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CHECKER_ID = table.Column<string>(nullable: true),
                    APPROVE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    EDITOR_ID = table.Column<string>(nullable: true),
                    EDIT_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    BankCode = table.Column<string>(nullable: true),
                    IdUserString = table.Column<int>(nullable: true),
                    MonthNumber = table.Column<int>(nullable: false),
                    ExpireDT = table.Column<DateTime>(type: "datetime", nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Subdomain = table.Column<string>(nullable: true),
                    FtpUser = table.Column<string>(nullable: true),
                    FtpPassword = table.Column<string>(nullable: true),
                    LinkAzure = table.Column<string>(nullable: true),
                    SqlUser = table.Column<string>(nullable: true),
                    SqlPass = table.Column<string>(nullable: true),
                    IsCheckOut = table.Column<string>(nullable: true),
                    AuthStatus = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    ValueString1 = table.Column<string>(nullable: true),
                    ValueString2 = table.Column<string>(nullable: true),
                    CheckID = table.Column<string>(nullable: true),
                    IsSentMailExpired = table.Column<string>(nullable: true),
                    IsTrial = table.Column<string>(nullable: true),
                    IsHot = table.Column<bool>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPackages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OW_OVERVIEW_ECOMMERCE",
                columns: table => new
                {
                    OVERVIEW_ECOMMERCE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PROJECT_ID = table.Column<string>(nullable: true),
                    SESSIONS = table.Column<string>(nullable: true),
                    PAGEVIEWS = table.Column<string>(nullable: true),
                    TIMEONPAGE = table.Column<string>(nullable: true),
                    TRANSACTIONREVENUE = table.Column<string>(nullable: true),
                    PRODUCTDETAILVIEWS = table.Column<string>(nullable: true),
                    PRODUCTADDSTOCART = table.Column<string>(nullable: true),
                    PRODUCTCHECKOUTS = table.Column<string>(nullable: true),
                    USERS = table.Column<string>(nullable: true),
                    NEWS_USERS = table.Column<string>(nullable: true),
                    DOMAIN = table.Column<string>(nullable: true),
                    VERSION = table.Column<string>(nullable: true),
                    VERSION_INT = table.Column<int>(nullable: false),
                    RECORD_STATUS = table.Column<string>(nullable: true),
                    AUTH_STATUS = table.Column<string>(nullable: true),
                    MAKER_ID = table.Column<string>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CHECKER_ID = table.Column<string>(nullable: true),
                    APPROVE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    EDITOR_ID = table.Column<string>(nullable: true),
                    EDIT_DT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OW_OVERVIEW_ECOMMERCE", x => x.OVERVIEW_ECOMMERCE_ID);
                });

            migrationBuilder.CreateTable(
                name: "OW_PAGE_BEHAVIOR_ECOMMERCE",
                columns: table => new
                {
                    PAGE_BEHAVIOR_ECOMMERCE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PROJECT_ID = table.Column<string>(nullable: true),
                    PAGE_PATH = table.Column<string>(nullable: true),
                    PAGE_VIEW = table.Column<string>(nullable: true),
                    PAGE_VALUE = table.Column<string>(nullable: true),
                    TIME_ON_PAGE = table.Column<string>(nullable: true),
                    EXIT_RATE = table.Column<string>(nullable: true),
                    DIMENSIONS = table.Column<string>(nullable: true),
                    DOMAIN = table.Column<string>(nullable: true),
                    VERSION_INT = table.Column<int>(nullable: false),
                    RECORD_STATUS = table.Column<string>(nullable: true),
                    AUTH_STATUS = table.Column<string>(nullable: true),
                    MAKER_ID = table.Column<string>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CHECKER_ID = table.Column<string>(nullable: true),
                    APPROVE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    EDITOR_ID = table.Column<string>(nullable: true),
                    EDIT_DT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OW_PAGE_BEHAVIOR_ECOMMERCE", x => x.PAGE_BEHAVIOR_ECOMMERCE_ID);
                });

            migrationBuilder.CreateTable(
                name: "OW_PRODUCT_PERFORMACE",
                columns: table => new
                {
                    OVERVIEW_ECOMMERCE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PROJECT_ID = table.Column<string>(nullable: true),
                    PRODUCT_NAME = table.Column<string>(nullable: true),
                    ITEM_REVENUE = table.Column<string>(nullable: true),
                    PRODUCT_DETAIL_VIEWS = table.Column<string>(nullable: true),
                    QUANTITY_ADDED_TO_CART = table.Column<string>(nullable: true),
                    QUANTITY_CHECKED_OUT = table.Column<string>(nullable: true),
                    DIMENSIONS = table.Column<string>(nullable: true),
                    DOMAIN = table.Column<string>(nullable: true),
                    VERSION = table.Column<string>(nullable: true),
                    VERSION_INT = table.Column<int>(nullable: false),
                    RECORD_STATUS = table.Column<string>(nullable: true),
                    AUTH_STATUS = table.Column<string>(nullable: true),
                    MAKER_ID = table.Column<string>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CHECKER_ID = table.Column<string>(nullable: true),
                    APPROVE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    EDITOR_ID = table.Column<string>(nullable: true),
                    EDIT_DT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OW_PRODUCT_PERFORMACE", x => x.OVERVIEW_ECOMMERCE_ID);
                });

            migrationBuilder.CreateTable(
                name: "OW_PRODUCTLIST_PERFORMANCE_ECOMMERCE",
                columns: table => new
                {
                    PRODUCTLIST_PERFORMANCE_ECOMMERCE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PROJECT_ID = table.Column<string>(nullable: true),
                    PRODUCTLIST = table.Column<string>(nullable: true),
                    ITEM_REVENUE = table.Column<string>(nullable: true),
                    PRODUCT_DETAIL_VIEWS = table.Column<string>(nullable: true),
                    QUANTITY_ADDED_TO_CART = table.Column<string>(nullable: true),
                    QUANTITY_CHECKED_OUT = table.Column<string>(nullable: true),
                    DIMENSIONS = table.Column<string>(nullable: true),
                    DOMAIN = table.Column<string>(nullable: true),
                    VERSION_INT = table.Column<int>(nullable: false),
                    RECORD_STATUS = table.Column<string>(nullable: true),
                    AUTH_STATUS = table.Column<string>(nullable: true),
                    MAKER_ID = table.Column<string>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CHECKER_ID = table.Column<string>(nullable: true),
                    APPROVE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    EDITOR_ID = table.Column<string>(nullable: true),
                    EDIT_DT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OW_PRODUCTLIST_PERFORMANCE_ECOMMERCE", x => x.PRODUCTLIST_PERFORMANCE_ECOMMERCE_ID);
                });

            migrationBuilder.CreateTable(
                name: "OW_SHOPPING_BEHAVIOR_ECOMMERCE",
                columns: table => new
                {
                    SHOPPING_BEHAVIOR_ECOMMERCE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PROJECT_ID = table.Column<string>(nullable: true),
                    USER_TYPE = table.Column<string>(nullable: true),
                    ITEM_REVENUE = table.Column<string>(nullable: true),
                    PRODUCT_DETAIL_VIEWS = table.Column<string>(nullable: true),
                    QUANTITY_ADDED_TO_CART = table.Column<string>(nullable: true),
                    QUANTITY_CHECKED_OUT = table.Column<string>(nullable: true),
                    DIMENSIONS = table.Column<string>(nullable: true),
                    DOMAIN = table.Column<string>(nullable: true),
                    VERSION_INT = table.Column<int>(nullable: false),
                    RECORD_STATUS = table.Column<string>(nullable: true),
                    AUTH_STATUS = table.Column<string>(nullable: true),
                    MAKER_ID = table.Column<string>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CHECKER_ID = table.Column<string>(nullable: true),
                    APPROVE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    EDITOR_ID = table.Column<string>(nullable: true),
                    EDIT_DT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OW_SHOPPING_BEHAVIOR_ECOMMERCE", x => x.SHOPPING_BEHAVIOR_ECOMMERCE_ID);
                });

            migrationBuilder.CreateTable(
                name: "OW_TRAFFIC_SOURCE_ECOMMERCE",
                columns: table => new
                {
                    TRAFFIC_SOURCE_ECOMMERCE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PROJECT_ID = table.Column<string>(nullable: true),
                    SOURCE = table.Column<string>(nullable: true),
                    MEDIUM = table.Column<string>(nullable: true),
                    SESSIONS = table.Column<string>(nullable: true),
                    SESSIONDURATION = table.Column<string>(nullable: true),
                    PAGEVIEWS = table.Column<string>(nullable: true),
                    EXITS = table.Column<string>(nullable: true),
                    TRANSACTIONS = table.Column<string>(nullable: true),
                    TRANSACTIONREVENUE = table.Column<string>(nullable: true),
                    DOMAIN = table.Column<string>(nullable: true),
                    VERSION = table.Column<string>(nullable: true),
                    VERSION_INT = table.Column<int>(nullable: false),
                    RECORD_STATUS = table.Column<string>(nullable: true),
                    AUTH_STATUS = table.Column<string>(nullable: true),
                    MAKER_ID = table.Column<string>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CHECKER_ID = table.Column<string>(nullable: true),
                    APPROVE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    EDITOR_ID = table.Column<string>(nullable: true),
                    EDIT_DT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OW_TRAFFIC_SOURCE_ECOMMERCE", x => x.TRAFFIC_SOURCE_ECOMMERCE_ID);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Alias = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    MetaKeyword = table.Column<string>(maxLength: 256, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SoTaiKhoan = table.Column<string>(maxLength: 100, nullable: true),
                    IdPackagePrices = table.Column<string>(maxLength: 100, nullable: true),
                    MaAdmin = table.Column<string>(maxLength: 128, nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    ThongTinNganHang = table.Column<string>(nullable: true),
                    HoTen = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    MetaKeyword = table.Column<string>(maxLength: 256, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    HomeOrder = table.Column<int>(nullable: true),
                    Image = table.Column<string>(maxLength: 256, nullable: true),
                    HomeFlag = table.Column<bool>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    MetaKeyword = table.Column<string>(maxLength: 256, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Alias = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    Image = table.Column<string>(maxLength: 256, nullable: true),
                    HomeFlag = table.Column<bool>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    MetaKeyword = table.Column<string>(maxLength: 256, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ValueString = table.Column<string>(nullable: true),
                    ValueHtml = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    PackageName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ValueString1 = table.Column<string>(nullable: true),
                    ValueString2 = table.Column<string>(nullable: true),
                    ValueString3 = table.Column<string>(nullable: true),
                    PriceValue = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    CategoryID = table.Column<int>(nullable: true),
                    Price1Month = table.Column<double>(nullable: true),
                    Price3Month = table.Column<double>(nullable: true),
                    Price6Month = table.Column<double>(nullable: true),
                    Price12Month = table.Column<double>(nullable: true),
                    Price24Month = table.Column<double>(nullable: true),
                    RECORD_STATUS = table.Column<string>(nullable: true),
                    AUTH_STATUS = table.Column<string>(nullable: true),
                    MAKER_ID = table.Column<string>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CHECKER_ID = table.Column<string>(nullable: true),
                    APPROVE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    EDITOR_ID = table.Column<string>(nullable: true),
                    EDIT_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    LinkAzure = table.Column<string>(nullable: true),
                    LinkBackupAzure = table.Column<string>(nullable: true),
                    ValueString4 = table.Column<string>(nullable: true),
                    ValueString5 = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    IsHot = table.Column<bool>(nullable: false),
                    ImageHorizontal = table.Column<string>(nullable: true),
                    ImageFull = table.Column<string>(nullable: true),
                    ShortDecription = table.Column<string>(nullable: true),
                    LinkDocument = table.Column<string>(nullable: true),
                    Banner1ImageLink = table.Column<string>(nullable: true),
                    Banner2ImageLink = table.Column<string>(nullable: true),
                    Banner3ImageLink = table.Column<string>(nullable: true),
                    Banner4ImageLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Alias = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    HomeOrder = table.Column<int>(nullable: true),
                    Image = table.Column<string>(maxLength: 256, nullable: true),
                    HomeFlag = table.Column<bool>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    MetaKeyword = table.Column<string>(maxLength: 256, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Image = table.Column<string>(maxLength: 256, nullable: true),
                    Url = table.Column<string>(maxLength: 256, nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SupportOnlines",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Department = table.Column<string>(maxLength: 50, nullable: true),
                    Skype = table.Column<string>(maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Yahoo = table.Column<string>(maxLength: 50, nullable: true),
                    Facebook = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportOnlines", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SystemConfigs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ValueString = table.Column<string>(nullable: true),
                    ValueInt = table.Column<int>(nullable: true),
                    ValueHtml = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemConfigs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserManualCategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Alias = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    HomeOrder = table.Column<int>(nullable: true),
                    Image = table.Column<string>(maxLength: 256, nullable: true),
                    HomeFlag = table.Column<bool>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    MetaKeyword = table.Column<string>(maxLength: 256, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserManualCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserManuals",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ValueString = table.Column<string>(nullable: true),
                    ValueHtml = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    ValueInt = table.Column<int>(nullable: true),
                    UserManualCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserManuals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VisitorStatistics",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    VisitedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IPAddress = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorStatistics", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 250, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dbo.Announcements_dbo.AppUsers_AppUser_Id",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    AppUser_Id = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_dbo.AppUserClaims_dbo.AppUsers_AppUser_Id",
                        column: x => x.AppUser_Id,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 128, nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    AppUser_Id = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_dbo.AppUserLogins_dbo.AppUsers_AppUser_Id",
                        column: x => x.AppUser_Id,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(maxLength: 128, nullable: false),
                    RoleId = table.Column<string>(maxLength: 128, nullable: false),
                    AppUser_Id = table.Column<string>(maxLength: 128, nullable: true),
                    IdentityRole_Id = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_dbo.AppUserRoles_dbo.AppUsers_AppUser_Id",
                        column: x => x.AppUser_Id,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.AppUserRoles_dbo.AppRoles_IdentityRole_Id",
                        column: x => x.IdentityRole_Id,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(maxLength: 256, nullable: false),
                    CustomerAddress = table.Column<string>(maxLength: 256, nullable: false),
                    CustomerEmail = table.Column<string>(maxLength: 256, nullable: false),
                    CustomerMobile = table.Column<string>(maxLength: 50, nullable: false),
                    CustomerMessage = table.Column<string>(maxLength: 256, nullable: false),
                    PaymentMethod = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    PaymentStatus = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dbo.Orders_dbo.AppUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GPermissions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(maxLength: 128, nullable: true),
                    FunctionId = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CanCreate = table.Column<bool>(nullable: false),
                    CanRead = table.Column<bool>(nullable: false),
                    CanUpdate = table.Column<bool>(nullable: false),
                    CanDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPermissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dbo.Permissions_dbo.Functions_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Functions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.Permissions_dbo.AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Alias = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    Image = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    HomeFlag = table.Column<bool>(nullable: true),
                    HotFlag = table.Column<bool>(nullable: true),
                    ViewCount = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    MetaKeyword = table.Column<string>(maxLength: 256, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dbo.Posts_dbo.PostCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "PostCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoInstructionCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PriceId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RECORD_STATUS = table.Column<string>(nullable: true),
                    AUTH_STATUS = table.Column<string>(nullable: true),
                    MAKER_ID = table.Column<string>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CHECKER_ID = table.Column<string>(nullable: true),
                    APPROVE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    EDITOR_ID = table.Column<string>(nullable: true),
                    EDIT_DT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoInstructionCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.VideoInstructionCategories_dbo.Prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Prices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Alias = table.Column<string>(maxLength: 256, nullable: false),
                    CategoryID = table.Column<int>(nullable: true),
                    ThumbnailImage = table.Column<string>(maxLength: 256, nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    OriginalPrice = table.Column<decimal>(nullable: true),
                    PromotionPrice = table.Column<decimal>(nullable: true),
                    IncludedVAT = table.Column<bool>(nullable: true),
                    Warranty = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    HomeFlag = table.Column<bool>(nullable: true),
                    HotFlag = table.Column<bool>(nullable: true),
                    ViewCount = table.Column<int>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    MetaKeyword = table.Column<string>(maxLength: 256, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dbo.Products_dbo.ProductCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "ProductCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementUsers",
                columns: table => new
                {
                    AnnouncementId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(maxLength: 128, nullable: false),
                    HasRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementUsers", x => new { x.AnnouncementId, x.UserId });
                    table.ForeignKey(
                        name: "FK_dbo.AnnouncementUsers_dbo.Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.AnnouncementUsers_dbo.AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    PostID = table.Column<int>(nullable: false),
                    TagID = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => new { x.PostID, x.TagID });
                    table.ForeignKey(
                        name: "FK_dbo.PostTags_dbo.Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.PostTags_dbo.Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoInstructions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VideoInstructionCategoryId = table.Column<int>(nullable: false),
                    YoutubeId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    RECORD_STATUS = table.Column<string>(nullable: true),
                    AUTH_STATUS = table.Column<string>(nullable: true),
                    MAKER_ID = table.Column<string>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CHECKER_ID = table.Column<string>(nullable: true),
                    APPROVE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    EDITOR_ID = table.Column<string>(nullable: true),
                    EDIT_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    Slug = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoInstructions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.VideoInstructions_dbo.VideoInstructionCategories_VideoInstructionCategoryId",
                        column: x => x.VideoInstructionCategoryId,
                        principalTable: "VideoInstructionCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    SizeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_dbo.OrderDetails_dbo.Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.OrderDetails_dbo.Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.OrderDetails_dbo.Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.OrderDetails_dbo.Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    Path = table.Column<string>(maxLength: 250, nullable: true),
                    Caption = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dbo.ProductImages_dbo.Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductQuantities",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    SizeId = table.Column<int>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductQuantities", x => new { x.ProductId, x.SizeId, x.ColorId });
                    table.ForeignKey(
                        name: "FK_dbo.ProductQuantities_dbo.Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.ProductQuantities_dbo.Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.ProductQuantities_dbo.Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    TagID = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => new { x.ProductID, x.TagID });
                    table.ForeignKey(
                        name: "FK_dbo.ProductTags_dbo.Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.ProductTags_dbo.Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "Announcements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementId",
                table: "AnnouncementUsers",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "AnnouncementUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_Id",
                table: "AppUserClaims",
                column: "AppUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_Id",
                table: "AppUserLogins",
                column: "AppUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_Id",
                table: "AppUserRoles",
                column: "AppUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRole_Id",
                table: "AppUserRoles",
                column: "IdentityRole_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParentId",
                table: "Functions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionId",
                table: "GPermissions",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleId",
                table: "GPermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorId",
                table: "OrderDetails",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductID",
                table: "OrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SizeId",
                table: "OrderDetails",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryID",
                table: "Posts",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PostID",
                table: "PostTags",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_TagID",
                table: "PostTags",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorId",
                table: "ProductQuantities",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductId",
                table: "ProductQuantities",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeId",
                table: "ProductQuantities",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductID",
                table: "ProductTags",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TagID",
                table: "ProductTags",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_PriceId",
                table: "VideoInstructionCategories",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoInstructionCategoryId",
                table: "VideoInstructions",
                column: "VideoInstructionCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdsPages");

            migrationBuilder.DropTable(
                name: "AlepayTransactionInfos");

            migrationBuilder.DropTable(
                name: "AnnouncementUsers");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "DemoTests");

            migrationBuilder.DropTable(
                name: "Errors");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Footers");

            migrationBuilder.DropTable(
                name: "GPermissions");

            migrationBuilder.DropTable(
                name: "MenuClients");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderPackages");

            migrationBuilder.DropTable(
                name: "OW_OVERVIEW_ECOMMERCE");

            migrationBuilder.DropTable(
                name: "OW_PAGE_BEHAVIOR_ECOMMERCE");

            migrationBuilder.DropTable(
                name: "OW_PRODUCT_PERFORMACE");

            migrationBuilder.DropTable(
                name: "OW_PRODUCTLIST_PERFORMANCE_ECOMMERCE");

            migrationBuilder.DropTable(
                name: "OW_SHOPPING_BEHAVIOR_ECOMMERCE");

            migrationBuilder.DropTable(
                name: "OW_TRAFFIC_SOURCE_ECOMMERCE");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductQuantities");

            migrationBuilder.DropTable(
                name: "ProductTags");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "SupportOnlines");

            migrationBuilder.DropTable(
                name: "SystemConfigs");

            migrationBuilder.DropTable(
                name: "UserManualCategories");

            migrationBuilder.DropTable(
                name: "UserManuals");

            migrationBuilder.DropTable(
                name: "VideoInstructions");

            migrationBuilder.DropTable(
                name: "VisitorStatistics");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "VideoInstructionCategories");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.AlterColumn<string>(
                name: "BrowserInfo",
                table: "AbpUserLoginAttempts",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BrowserInfo",
                table: "AbpEntityChangeSets",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BrowserInfo",
                table: "AbpAuditLogs",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 512,
                oldNullable: true);
        }
    }
}
