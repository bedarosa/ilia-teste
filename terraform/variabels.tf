variable "aws_region" {
  description = "AWS Region"
  default     = "us-east-1"
}

variable "vpc_name" {
  description = "Name of the VPC"
  default     = "my-eks-vpc"
}

variable "vpc_cidr" {
  description = "CIDR block for the VPC"
  default     = "10.0.0.0/16"
}

variable "vpc_azs" {
  description = "Availability Zones"
  type        = list(string)
  default     = ["us-east-1a", "us-east-1b", "us-east-1c"]
}

variable "vpc_private_subnets" {
  description = "Private Subnets"
  type        = list(string)
  default     = ["10.0.1.0/24", "10.0.2.0/24"]
}

variable "vpc_public_subnets" {
  description = "Public Subnets"
  type        = list(string)
  default     = ["10.0.101.0/24", "10.0.102.0/24"]
}

variable "enable_dns_hostnames" {
  description = "Enable DNS hostnames in VPC"
  type        = bool
  default     = true
}

variable "enable_dns_support" {
  description = "Enable DNS support in VPC"
  type        = bool
  default     = true
}

variable "eks_cluster_name" {
  description = "Name of the EKS Cluster"
  default     = "my-eks-cluster"
}

variable "eks_cluster_version" {
  description = "Version of EKS Cluster"
  default     = "1.24"
}

variable "node_group_desired_capacity" {
  description = "Desired number of nodes in the EKS node group"
  default     = 2
}

variable "node_group_min_size" {
  description = "Minimum number of nodes in the EKS node group"
  default     = 2
}

variable "node_group_max_size" {
  description = "Maximum number of nodes in the EKS node group"
  default     = 5
}

variable "node_group_instance_type" {
  description = "Instance type for EKS node group"
  default     = "t3.medium"
}

variable "eip_count" {
  description = "Number of Elastic IPs for NAT"
  default     = 1
}
