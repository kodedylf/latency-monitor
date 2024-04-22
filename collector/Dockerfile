FROM debian:latest
RUN apt update && apt install -y moreutils iputils-ping
CMD ping -i 10 google.com | sed -u -r 's/.*time=([^ ]+).*/\1/' | sed -u -e 1d | ts '%Y-%m-%dT%H:%M:%S%z ' >> /var/ping.log
