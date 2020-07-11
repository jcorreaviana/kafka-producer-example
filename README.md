# An Example of Confluence Kafka Producer using .NET Core

### Wanna build a .NET Core Kafka Consumer example? See my repo at https://github.com/jcorreaviana/kafka-consumer-example

## Stack of sample

| Option | Description | Default Port in docker-file
| :------:| :-----------:| :------: |
| .NET Core   | [.NET Core Version 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) |  ```http://localhost:8082```|
| Kafka Host (set to go in docker compose file) | [From Docker Hub](https://hub.docker.com/r/prom/prometheus/) |```http://localhost:9092```|
| Zookeeper (set to go in docker compose file)   | [From Dcoker Hub](https://hub.docker.com/r/grafana/grafana/) |```2181```|


## Steps to run in your machine

### 1. Clone the repository and run the following commands:

``` csharp
dotnet restore
```

``` csharp
dotnet build
```

### 2. Build the image of your API:

Where "netcorekafkaproducer" is an example of name choosed for one image

```
docker build --no-cache -t netcorekafkaproducer .     
```

### 3. Run the "docker-file":

If you change the name of image, change the value of image in `docker-compose` file to mantaint it consistent. Then, in the directory where the docker-file is, run 

```
docker-compose up       
```

### 4. Try list your Kafka topics:

To do this, run in your terminal (in this case, running in Ubuntu 20.04)

```
kafka-topics.sh --bootstrap-server localhost:9092 --list       
```

![Result 1](https://github.com/jcorreaviana/kakfa-producer-example/blob/master/images/topics-host-list-example.jpeg?raw=true)

### 5. Prepare one console consumer

To do this, run in your terminal (in this case, running in Ubuntu 20.04)

```
kafka-console-consumer.sh --bootstrap-server localhost:9092 --topic kafka-topic --property print.key=true --property key.separator=:     
```

The last two parameters is for show the key of message in terminal and the second to use ":" for separate the key and message.

Example: <i>key_value</i><strong> : </strong><i>message_value</i>

### 6. Send some requests in .NET Core Web API

<strong>Suggestions to send beautiful examples? Use brazilians classic cars :)</strong>

``` json
{
  "model": "Opala",
  "year": "1987"
}
...
{
  "model": "Gol GTS",
  "year": "1989"
}
```

And others... :)

This result is like this.

![Result 2](https://github.com/jcorreaviana/kakfa-producer-example/blob/master/images/response-example.jpeg?raw=true)


### 7. See the messages in your consumer

![Result 3](https://github.com/jcorreaviana/kakfa-producer-example/blob/master/images/consumer-example.jpeg?raw=true)

### Wanna build a .NET Core Kafka Consumer example? See my repo at https://github.com/jcorreaviana/kafka-consumer-example

#iswe
