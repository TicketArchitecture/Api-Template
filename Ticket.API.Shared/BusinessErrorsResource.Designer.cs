﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ticket.API.Shared {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class BusinessErrorsResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal BusinessErrorsResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Ticket.API.Shared.BusinessErrorsResource", typeof(BusinessErrorsResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Repetição não permitida para o campo {0}..
        /// </summary>
        public static string DadoDuplicadoNaoPermitido {
            get {
                return ResourceManager.GetString("DadoDuplicadoNaoPermitido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Houve um erro inesperado. As informações não foram salvas. Por favor tente novamente..
        /// </summary>
        public static string ErroInesperadoInsert {
            get {
                return ResourceManager.GetString("ErroInesperadoInsert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Esta é uma mensagem de erro padrão. Verifique se utilizou o nome correto do Resource..
        /// </summary>
        public static string ErroPadrao {
            get {
                return ResourceManager.GetString("ErroPadrao", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Id deve ser maior que 0..
        /// </summary>
        public static string NovoEstabelecimentoFavoritoId {
            get {
                return ResourceManager.GetString("NovoEstabelecimentoFavoritoId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to São válidas as notas: 1, 2, 3, 4 e 5..
        /// </summary>
        public static string NovoEstabelecimentoFavoritoNotaAtribuida {
            get {
                return ResourceManager.GetString("NovoEstabelecimentoFavoritoNotaAtribuida", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Texto de Teste..
        /// </summary>
        public static string SharedTests {
            get {
                return ResourceManager.GetString("SharedTests", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Número de telefone inválido..
        /// </summary>
        public static string TelefoneNumero {
            get {
                return ResourceManager.GetString("TelefoneNumero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SO é obrigatório..
        /// </summary>
        public static string TelefoneSistemaOperacional {
            get {
                return ResourceManager.GetString("TelefoneSistemaOperacional", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UUID é obrigatório..
        /// </summary>
        public static string TelefoneUUID {
            get {
                return ResourceManager.GetString("TelefoneUUID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O Email é obrigatório e deve ser válido. .
        /// </summary>
        public static string UsuarioEmail {
            get {
                return ResourceManager.GetString("UsuarioEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O email informado já está em uso. Possivelmente você já possui cadastro conosco..
        /// </summary>
        public static string UsuarioEmailDuplicado {
            get {
                return ResourceManager.GetString("UsuarioEmailDuplicado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O nome deve conter ao menos 5 caracteres alfanuméricos..
        /// </summary>
        public static string UsuarioNome {
            get {
                return ResourceManager.GetString("UsuarioNome", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Valor Nulo não permitido..
        /// </summary>
        public static string ValorNuloNaoPermitido {
            get {
                return ResourceManager.GetString("ValorNuloNaoPermitido", resourceCulture);
            }
        }
    }
}
