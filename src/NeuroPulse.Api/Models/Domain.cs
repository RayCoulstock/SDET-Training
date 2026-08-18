namespace NeuroPulse.Api.Models;
public enum ParticipantStatus { Active, Inactive }
public enum ConnectionStatus { Connected, Disconnected, Unknown }
public enum SessionStatus { Pending, Recording, Completed, Failed }
public class Participant { public int Id {get;set;} public string FirstName {get;set;}=""; public string LastName {get;set;}=""; public string Email {get;set;}=""; public DateOnly DateOfBirth {get;set;} public ParticipantStatus Status {get;set;} public DateTime CreatedAt {get;set;} }
public class Device { public int Id {get;set;} public string SerialNumber {get;set;}=""; public string Model {get;set;}="NeuroBand X"; public string FirmwareVersion {get;set;}="1.4.2"; public int BatteryPercentage {get;set;} public ConnectionStatus ConnectionStatus {get;set;} public int? AssignedParticipantId {get;set;} public Participant? AssignedParticipant {get;set;} public DateTime LastSeenAt {get;set;} }
public class RecordingSession { public int Id {get;set;} public int ParticipantId {get;set;} public Participant? Participant {get;set;} public int DeviceId {get;set;} public Device? Device {get;set;} public DateTime StartedAt {get;set;} public DateTime? EndedAt {get;set;} public SessionStatus Status {get;set;} public double AverageSignal {get;set;} public double SignalQuality {get;set;} public string Notes {get;set;}=""; }
public class TelemetryReading { public int Id {get;set;} public int SessionId {get;set;} public RecordingSession? Session {get;set;} public string DeviceId {get;set;}=""; public DateTime Timestamp {get;set;} public double Signal {get;set;} public double Quality {get;set;} public int BatteryPercentage {get;set;} }
public record ParticipantRequest(string FirstName,string LastName,string Email,DateOnly DateOfBirth,ParticipantStatus Status);
public record DeviceRequest(string SerialNumber,string Model,string FirmwareVersion,int BatteryPercentage,ConnectionStatus ConnectionStatus);
public record AssignmentRequest(int ParticipantId);
public record SessionRequest(int ParticipantId,int DeviceId);
public record TelemetryRequest(string DeviceId,int SessionId,DateTime Timestamp,double Signal,double Quality,int BatteryPercentage);
public record DeviceStatus(string DeviceId,bool Connected,int Battery);
