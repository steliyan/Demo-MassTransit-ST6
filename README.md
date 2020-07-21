# MassTransit distributed transactions DMO

A sample code illustrating how to implement distributed transactions using **MassTransit**.

## Requirements

- [VS Code](https://code.visualstudio.com/)
- [.NET Core 3.1](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/)

## Getting started

### RabbitMQ

```bash
docker-compose up # Run RabbitMQ in a docker container
```

_This step is optional, if you already have a **RabbitMQ** instance running. Please note, that `test` virtual host is used in the configuration app.config files._

### Build

```bash
dotnet build
```

### Run client

```bash
cd Client
dotnet run
```

### Run payment service

```bash
cd PaymentService
dotnet run
```

### Run pizza service

```bash
cd PizzaService
dotnet run
```

\* `dotnet watch run` can be used instead of `dotnet run` if hot-reloading is needed. ;)

## Additional Resources

- MassTransit [docs](https://masstransit-project.com/getting-started/)
  - [Common mistakes](https://masstransit-project.com/troubleshooting/common-gotchas.html)
  - [Other samples](https://masstransit-project.com/learn/samples.html)
- MassTransit's author's YouTube [channel](https://www.youtube.com/playlist?list=PLx8uyNNs1ri2MBx6BjPum5j9_MMdIfM9C)
