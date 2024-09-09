provider "aws" {
  region = var.aws_region
}

module "vpc" {
  source  = "terraform-aws-modules/vpc/aws"
  version = "5.13.0"

  name = var.vpc_name
  cidr = var.vpc_cidr

  azs             = var.vpc_azs
  private_subnets = var.vpc_private_subnets
  public_subnets  = var.vpc_public_subnets

  enable_dns_hostnames = var.enable_dns_hostnames
  enable_dns_support   = var.enable_dns_support
}

module "eks_cluster" {
  source  = "terraform-aws-modules/eks/aws"
  version = "17.0.0"

  cluster_name    = var.eks_cluster_name
  cluster_version = var.eks_cluster_version

  vpc_id  = module.vpc.vpc_id
  subnets = module.vpc.public_subnets

  node_groups = {
    my_node_group = {
      desired_capacity = var.node_group_desired_capacity
      min_size         = var.node_group_min_size
      max_size         = var.node_group_max_size
      instance_type    = var.node_group_instance_type
    }
  }
}
