using Lab5.Enums;

namespace Lab5.Models;

public record NotificationMessage(string Text, NotificationType Type, int Duration = 3000);
