call npx @apidevtools/swagger-cli bundle openapi.yaml --outfile ./build/merged.yaml --type yaml  --enable-post-process-file true
call npx @openapitools/openapi-generator-cli generate -i ./build/merged.yaml -g csharp-netcore-functions -o ../backend
@REM call npx @openapitools/openapi-generator-cli generate -i ./build/merged.yaml -g typescript-fetch -o ../frontend/src