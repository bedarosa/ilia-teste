#!/bin/bash

set -e

NAMESPACE="monitoring"

echo "Creating namespace '$NAMESPACE' if not exists..."
kubectl create namespace $NAMESPACE || true

echo "Adding Helm repositories..."

helm repo add grafana https://grafana.github.io/helm-charts
helm repo add prometheus-community https://prometheus-community.github.io/helm-charts
helm repo update

echo "Installing Prometheus..."

helm install prometheus prometheus-community/prometheus \
  --namespace $NAMESPACE \
  --create-namespace

echo "Installing Loki (with Promtail)..."

helm install loki grafana/loki-stack \
  --namespace $NAMESPACE

echo "Installing Grafana..."

helm install grafana grafana/grafana \
  --namespace $NAMESPACE


echo "Waiting for Grafana to be deployed..."
kubectl rollout status deployment/grafana -n $NAMESPACE


GRAFANA_ADMIN_PASSWORD=$(kubectl get secret --namespace $NAMESPACE grafana -o jsonpath="{.data.admin-password}" | base64 --decode)

echo "Grafana admin password: $GRAFANA_ADMIN_PASSWORD"
echo "Port-forwarding Grafana to http://localhost:3000..."
echo "To access Grafana, visit: http://localhost:3000 with username 'admin' and password '$GRAFANA_ADMIN_PASSWORD'"


kubectl port-forward --namespace $NAMESPACE svc/grafana 3000:80


echo "Setup complete. Grafana is running on http://localhost:3000"
echo "Add Prometheus and Loki as data sources in Grafana manually."
echo "Prometheus URL: http://prometheus-server.$NAMESPACE.svc.cluster.local"
echo "Loki URL: http://loki.$NAMESPACE.svc.cluster.local"
