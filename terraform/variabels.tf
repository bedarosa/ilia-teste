variable "aws_access_key" {
  description = "AWS Access Key"
}

variable "aws_secret_key" {
  description = "AWS Secret Key"
}

variable "aws_region" {
  description = "AWS Region"
  default     = "us-west-2"
}

variable "eks_cluster_name" {
  description = "EKS Cluster Name"
  default     = "my-eks-cluster"
}

variable "eks_cluster_version" {
  description = "EKS Cluster Version"
  default     = "1.21"
}

variable "vpc_cidr_block" {
  description = "VPC CIDR Block"
  default     = "10.0.0.0/16"
}

variable "vpc_azs" {
  description = "VPC Availability Zones"
  default     = ["us-west-2a", "us-west-2b", "us-west-2c"]
}

variable "vpc_private_subnets" {
  description = "VPC Private Subnets"
  default     = ["10.0.1.0/24", "10.0.2.0/24", "10.0.3.0/24"]
}

variable "vpc_public_subnets" {
  description = "VPC Public Subnets"
  default     = ["10.0.101.0/24", "10.0.102.0/24", "10.0.103.0/24"]
}

variable "eks_worker_instance_type" {
  description = "EKS Worker Instance Type"
  default     = "t3"
}