# Monitor your Internet latency using ping

I'm having some weird latency spikes on my Internet connection and this project is meant to help me figure out if there's a pattern to when it happens.

The project runs 2 containers: one that collects latency data using ping and another that exposes the data as JSON and also contains a small UI that shows the latency as a graph.

To run the monitor, use the following commands
```
touch ping.log
docker compose up -d
```

Then go to `http://localhost:8080/` to see the graph.
