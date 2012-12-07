using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
/// <summary>
/// Summary description for Class1
/// </summary>
public static class Global 
{
    //FRIENDS STATUS
    public const string CONFIRMED = "C";
    public const string PENDING = "P";
    public const string NOTNOW = "N";
    public const string SUGGESTED = "S";


    //ACTIVITIES
    public const string ACTIVITIES = "A";
    public const string INTERESTS = "I";


    //ENTERTAINMENT & SPORTS
    public const string MUSIC = "C";
    public const string BOOKS = "I";
    public const string MOVIE = "M";
    public const string TELEVISION = "T";
    public const string GAME = "G";
    public const string SPORTS = "S";
    public const string ATHELETE = "H";
    public const string TEAM = "E";
    

    //TYPE FOR MEDIA COMMENTS LIKE TAG WALL SHARE
    public const int PHOTO = 1;
    public const int VIDEO = 2;
    public const int PHOTO_ALBUM = 3;
    public const int VIDEO_ALBUM = 4;
    public const int WALL = 5;
    public const int TEXT_POST = 6;
    public const int WALL_COMMENT = 7;
    public const int TAG_POST = 8;
    public const int POST_VIDEOLINK = 15;
    public const int PROFILE_CHANGE= 10;
    public const int TAG_VIDEO = 11;
    public const int TAG_VIDEOLINK = 12;
    public const int TAG_PHOTO = 13;
    public const int TAG_PHOTO_ALBUM = 14;
    public const int LINK= 16;
    public const int SHARE = 9;

    //weights for social features
    public const int WEIGHT_LIST = 6;
    public const int WEIGHT_INTERESTS = 5;
    public const int WEIGHT_WORKPLACE = 4;
    public const int WEIGHT_EDUCATION = 4;
    public const int WEIGHT_HOMETOWN = 2;
    public const int WEIGHT_GENDER = 2;
    public const int WEIGHT_SHAREDFRIENDS = 8;
    public const int WEIGHT_RELIGIONPOLITICS = 2;

    public const int SUGGESTIONS_MINIMUM_SCORE = 2;

    //weights for post types
    public const int WEIGHT_PHOTO = 5;
    public const int WEIGHT_VIDEO = 4;
    public const int WEIGHT_VIDEOLINK = 3;
    public const int WEIGHT_TEXT = 2;

    //Values for Post Status
    public const int POST_HIDDEN = 1;
    public const int POST_SPAM = 2;

    //Values for Post Status Updates Type (All, Only Imp, Most Updates )
    public const int POST_ALL = 1;
    public const int POST_MOST = 2;
    public const int POST_ONLYIMP = 3;

    //Profile Picture
   // public const string PROFILE_PICTURE= "~/UI/UserProfile/profileimages/";
    
    public static string PROFILE_PICTURE = ConfigurationSettings.AppSettings["PathProfilePicture"];

    
    //User Photos
    public static string USER_PHOTOS = ConfigurationSettings.AppSettings["PathUserPhotos"];
    public static string THUMBNAIL_PHOTOS = ConfigurationSettings.AppSettings["PathThumbnailPhotos"];
    //User Photos
    public static string USER_VIDEO = ConfigurationSettings.AppSettings["PathUserVideos"];
    public static string PATH_COMPRESSED_USER_VIDEO = ConfigurationSettings.AppSettings["PathCompressedVideos"];
    // 
    public const string Signup_Mail_Link = "http://203.135.63.151:8080/team5/UI/SignUp/";

    public const string JUST_NOW = "Just now";
    public const string ONE_MINUTE_AGO = "1 minute ago";
    public const string ONE_HOUR_AGO = "1 hour ago";
    public const string YESTERDAY = "yesterday";
    public const string LAST_WEEK = "last week";
    public const string TWO_WEEKS_AGO = "2 weeks ago";
    public const string THREE_WEEKS_AGO = "3 weeks ago";
    public const string LAST_MONTH = "last month";
    public const string LAST_YEAR = "last year";
    public const string MONTHS_AGO = "{0} months ago";
    public const string YEARS_AGO = "{0} years ago";
    public const string DAYS_AGO = "{0} days ago";
    public const string HOURS_AGO = "{0} hours ago";
    public const string MINTUES_AGO = "{0} minutes ago";
    public const string NOT_YET = "not yet";

    public const string SHARE_A_POST = "share a post";

    public const string SESSION_USER_ID = "UserId";
    public const string SESSION_PHOTO_ALBUM_ID = "PhotoAlbumId";
    public const string SESSION_TEMP_USER_ID = "TempUserId";
    public const string SESSION_POST_TYPE = "PostType";
    public const string SESSION_EMBED_POST = "EmbedPost";
    public const string SESSION_SHARE_WITH_ID = "ShareWithID";
    public const string SESSION_POST_ID = "PostID";
    public const string SESSION_TAGGED_FRIENDS = "TaggedFriends";

    public const string POST_ACTIVITY_TEXT = "Changed Activities & Interests";
    public const string POST_CHANGED_BASIC_INFO = "Changed Basic Information";
    public const string POST_CHANGED_CONTACT_INFO = "Changed Contact Information";
    public const string POST_CHANGED_EDUCATION_WORK = "Changed Education Work";
    public const string POST_CHANGED_ENTERTAINMENT = "Changed Entertainment";
    public const string POST_CHANGED_RELATIONSHIP_STATUS = "Changed Relationship Status";
    public const string POST_PROFILE_PICTIRE_CHANGE = "Profile Picture Change";
    public const string POST_USER_CHNAGED_SPORTS = "User Changed Sports";

    public const string PICTURE_EXTENSION_JPG = ".jpg";

    public const string FRIEND_AND_FAMILY = "Friends and Family";
    public const string SESSION_USER_EMIAL = "UserEmail";

    public const string SET_NEW_PASSWORD = "Set New Password";
    public const string ACCOUNT_ACTIVATION = "Account Activation";
    public const string TERMS_AND_CONDITIONS = "Terms And Conditions";
    public const string ENTER_PHONE_NUMBER = "Enter Phone Number";
    public const string CANNOT_IDENTIFY_ACCOUNT = "Can't Idfentify Account";

    public const string PASSWORD_RESET_CODES_SENT = "Password reset codes sent";

    public const string INCORRECT_PASSWORD = "Incorrect Password";
    public const string MISSPELLING_FIXED = "Misspelling Fixed";

    public const string IDENTIFY_YPUR_ACCOUNT = "Identify your account";

    public const string PLEASE_REENTER_YOUR_PASSWORD = "Please Re-enter your Password";
    public const string RESET_YOUR_PASSWORD = "Reset your Password";






















}