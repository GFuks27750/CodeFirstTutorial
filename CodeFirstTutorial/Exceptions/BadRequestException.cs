namespace CodeFirstTutorial.Exceptions;

public class BadRequestException(string message) : Exception(message);