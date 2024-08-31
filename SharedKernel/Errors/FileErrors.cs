using System.Net;

namespace SharedKernel.Errors;

public static class FileErrors
{
    public static readonly Error FileNotFound = new("Files.NotFound", (int)HttpStatusCode.NotFound, "File is not found");
    public static readonly Error InvalidFileType = new("Files.InvalidType", (int)HttpStatusCode.BadRequest, "The file type provided is invalid");
    public static readonly Error FileTooLarge = new("Files.TooLarge", (int)HttpStatusCode.BadRequest, "The file size exceeds the allowed limit");
    public static readonly Error FileUploadFailed = new("Files.UploadFailed", (int)HttpStatusCode.InternalServerError, "File upload failed due to server error");
    public static readonly Error FileAccessDenied = new("Files.AccessDenied", (int)HttpStatusCode.Forbidden, "Access to the file is denied");
    public static readonly Error FileAlreadyExists = new("Files.AlreadyExists", (int)HttpStatusCode.Conflict, "A file with this name already exists");
    public static readonly Error FileCorrupted = new("Files.Corrupted", (int)HttpStatusCode.BadRequest, "The file is corrupted and cannot be processed");
    public static readonly Error FileReadError = new("Files.ReadError", (int)HttpStatusCode.InternalServerError, "An error occurred while reading the file");
    public static readonly Error FileWriteError = new("Files.WriteError", (int)HttpStatusCode.InternalServerError, "An error occurred while writing the file");
    public static readonly Error UnsupportedFileFormat = new("Files.UnsupportedFormat", (int)HttpStatusCode.BadRequest, "The file format is not supported");
}