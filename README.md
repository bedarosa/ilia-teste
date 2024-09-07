
# Ília Test

Challenge of the selection process for the DevOps vacancy at Ília Digital




## Workflow

This project has a Workflow that, every time a commit is made to the `master` branch, creates a Docker image and pushes it to my Docker Hub `https://hub.docker.com/repository/docker/bernardopinheiro`

```bash
docker pull bernardopinheiro/ilia-docker:latest
```



## API Documentation

#### Get All Products

```http
  GET /api/Product
```

#### Get a Product

```http
  GET /api/Product/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Required**. The ID of the Product |


#### Create a Product

```http
  POST /api/Product
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `name`      | `string` | **Required**. The name of the item |
| `price`      | `float` | **Required**. The price of the item |
| `description`      | `string` | **Required**. The description of the item |

#### Update a Product

```http
  PUT /api/Product/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Required**. The ID of the product |
| `name`      | `string` | **Opcional**.  The new name of the product |
| `price`      | `float` | **Opcional**.  The new price of the product |
| `description`      | `string` | **Opcional**. The new description of the product |

#### Delete a Product

```http
  DELETE /api/Product/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Required**. The ID of the item |
