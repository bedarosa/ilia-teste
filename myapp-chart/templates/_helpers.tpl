{{- define "myapp-chart.fullname" -}}
{{- printf "%s-%s" .Release.Name .Chart.Name | trunc 63 | trimSuffix "-" -}}
{{- end -}}

{{- define "myapp-chart.name" -}}
{{- .Chart.Name -}}
{{- end -}}
