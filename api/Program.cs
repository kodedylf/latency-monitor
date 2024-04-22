using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/data", () =>
    {
        // Use 'tail' to efficiently read the last 200 lines of the ping log file
        string pingLines;
        using (Process process = new Process())
        {
            process.StartInfo.FileName = "/usr/bin/tail";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.Arguments = "-200 /var/ping.log";
            process.Start();
            pingLines = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
        }

        var pingData = new List<PingData>();
        foreach (var pingLine in pingLines.Split(Environment.NewLine))
        {
            var elements = pingLine.Split("  ");
            if (elements.Count() == 2) {
                var timestamp = DateTime.Parse(elements[0]);
                var latency = float.Parse(elements[1]);
                pingData.Add(new PingData(timestamp, latency));
            }
        }
        return pingData;
    })
    .WithOpenApi();

app.Run();

record PingData(DateTime Time, float Ping)
{
}
